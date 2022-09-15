using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controllers;
using TokoBeDia.Models;

namespace TokoBeDia.Views
{
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                if (!isAdmin())
                {
                    Response.Redirect("home.aspx");
                }
                LbName.Text = (Session["user"] as Users).Name;
            }
            else
            {
                Response.Redirect("home.aspx");
            }

            BindGridList();
        }

        protected void BindGridList()
        {
            GvPaymentType.DataSource = PaymentTypeController.GetAllPaymentType();
            GvPaymentType.DataBind();

        }

        protected bool isAdmin()
        {
            return (Session["user"] as Users).Roles.Name == "Administrator" ? true : false;
        }

        protected void GvPaymentType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int typeID = Int32.Parse(GvPaymentType.Rows[rowIndex].Cells[0].Text);
            alertRed.Visible = false;
            alertGreen.Visible = false;
            PaymentTypes deletedPaymentType = PaymentTypeController.DeleteById(typeID);
            if (deletedPaymentType == null)
            {
                alertRed.Text = "Delete failed, payment type is referenced by certain transaction!";
                alertRed.Visible = true;
            }
            else
            {
                BindGridList();
                alertGreen.Text = "Payment type id: " + deletedPaymentType.ID + " Deleted!";
                alertGreen.Visible = true;
            }


        }

        protected void GvPaymentType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string typeId = GvPaymentType.Rows[rowIndex].Cells[0].Text;

            Response.Redirect("UpdatePaymentType.aspx?typeId=" + typeId);
        }
    }
}