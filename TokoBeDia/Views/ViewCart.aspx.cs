using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controllers;
using TokoBeDia.Models;
using TokoBeDia.ViewModel;

namespace TokoBeDia.Views
{
    public partial class ViewCart : System.Web.UI.Page
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
     
                if (Session["user"] == null || isAdmin())
                {
                    Response.Redirect("Home.aspx");
                }

                LbName.Text = (Session["user"] as Users).Name;
                userId = (Session["user"] as Users).ID;
                BindGridList();
                bindDdl();
            }

        }

        protected void BindGridList()
        {
            List<ProductCartViewModel> vm = CartController.GetCartViewModelByUserId(userId);
            GvViewCart.DataSource = vm;
            GvViewCart.DataBind();
            if (vm.Count == 0)
            {
                lblNoItem.Visible = true;
                ddlPayment.Visible = false;
                ddlPayment.Enabled = false;
                btnCheckout.Enabled = false;
                btnCheckout.Visible = false;
            }
        }

        protected void GvViewCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string productId = GvViewCart.Rows[rowIndex].Cells[0].Text;

            Response.Redirect("UpdateCart.aspx?productId=" + productId);

        }

        protected void GvViewCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int productId = Int32.Parse(GvViewCart.Rows[rowIndex].Cells[0].Text);
            userId = (Session["user"] as Users).ID;
            alertRed.Visible = false;
            alertGreen.Visible = false;
            Carts deletedCart = CartController.DeleteCartById(productId,userId);
            

            if (deletedCart != null)
            {
                BindGridList();
                alertGreen.Text = "Product id: " + deletedCart.ProductID + " Deleted!";
                alertGreen.Visible = true;

            }
            else
            {
                Response.Redirect(Request.Url.ToString());
            }

            if(GvViewCart.Rows.Count == 0) { 
                lblGrandTotal.Text = "0";
                lblGrandTotal.Visible = false;
                lblNoItem.Visible = true;
                ddlPayment.Visible = false;
                ddlPayment.Enabled = false;
                btnCheckout.Enabled = false;
                btnCheckout.Visible = false;
            }

        }

        protected bool isAdmin()
        {
            return (Session["user"] as Users).Roles.Name == "Administrator" ? true : false;
        }

        protected void bindDdl()
        {
            ddlPayment.DataSource = PaymentTypeController.GetAllPaymentType();
            ddlPayment.Items.Add(new ListItem("<-Select Payment Type->", "0"));
            ddlPayment.DataTextField = "Type";
            ddlPayment.DataValueField = "ID";
            ddlPayment.DataBind();
            ddlPayment.SelectedValue = "0";
        }

        int grandTotal = 0;
        protected void GvViewCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                    grandTotal += int.Parse(e.Row.Cells[4].Text);

            }
            lblGrandTotal.Text = "Grand Total: " + grandTotal.ToString();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int value = int.Parse(ddlPayment.SelectedValue);
            userId = (Session["user"] as Users).ID;
            if (GvViewCart.Rows.Count != 0)
            {
                CartController.CheckOut(userId, value);
            }
            Response.Redirect(Request.Url.ToString());
        }
    }
}