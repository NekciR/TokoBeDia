using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controllers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Views
{
    public partial class ViewProductType : System.Web.UI.Page
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
            GvProductType.DataSource = ProductTypeController.GetAllProductType();
            GvProductType.DataBind();
            
        }

        protected bool isAdmin()
        {
            return (Session["user"] as Users).Roles.Name == "Administrator" ? true : false;
        }

        protected void GvProductType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int typeID = Int32.Parse(GvProductType.Rows[rowIndex].Cells[0].Text);
            alertRed.Visible = false;
            alertGreen.Visible = false;
            ProductTypes deletedProductsType = ProductTypeController.DeleteById(typeID);
            if (deletedProductsType == null)
            {
                alertRed.Text = "Delete failed, product type is referenced by certain product!";
                alertRed.Visible = true;
            }
            else
            {
                BindGridList();
                alertGreen.Text = "Product type id: " + deletedProductsType.ID + " Deleted!";
                alertGreen.Visible = true;
            }
            

        }

        protected void GvProductType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string typeId = GvProductType.Rows[rowIndex].Cells[0].Text;

            Response.Redirect("UpdateProductType.aspx?typeId=" + typeId);
        }
    }
}