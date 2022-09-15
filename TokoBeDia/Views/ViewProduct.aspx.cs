using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controllers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Views
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!IsPostBack)
            {
                AdminControl.Visible = false;
                if (Session["user"] != null)
                {
                    LbName.Text = (Session["user"] as Users).Name;

                    if (isAdmin())
                    {
                        AdminControl.Visible = true;
                    }
                    else
                    {
                        AdminControl.Visible = false;
                    }
                }
                
                BindGridList();
            }

        }

        protected void BindGridList()
        {
            GvViewProduct.DataSource = ProductController.getAllProduct();
            GvViewProduct.DataBind();
        }

        protected void GvViewProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string productId = GvViewProduct.Rows[rowIndex].Cells[0].Text;

            Response.Redirect("UpdateProduct.aspx?productId=" + productId);

        }

        protected void GvViewProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int productId = Int32.Parse(GvViewProduct.Rows[rowIndex].Cells[0].Text);
            alertRed.Visible = false;
            alertGreen.Visible = false;
            Products deletedProduct = ProductController.DeleteProductById(productId);

            if(deletedProduct != null)
            {
                BindGridList();
                alertGreen.Text = "Product type id: " + deletedProduct.ID + " Deleted!";
                alertGreen.Visible = true;

            }
            else
            {
                alertRed.Text = "Delete failed, product is referenced by certain transaction!";
                alertRed.Visible = true;
            }

        }

        protected void GvViewProduct_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (Session["user"] == null)
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
            }
            else
            {
                if (isAdmin())
                {
                    e.Row.Cells[6].Visible = true;
                    e.Row.Cells[5].Visible = true;
                    e.Row.Cells[0].Visible = true;
                    e.Row.Cells[4].Visible = false;
                }
                else
                {
                    e.Row.Cells[4].Visible = true;
                    e.Row.Cells[0].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                }

            }
        }

        protected bool isAdmin()
        {
            return (Session["user"] as Users).Roles.Name == "Administrator" ? true : false;
        }

        protected void GvViewProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "AddToCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string productId = GvViewProduct.Rows[rowIndex].Cells[0].Text;
                Response.Redirect("AddToCart.aspx?productId=" + productId);

            }
        }
    }
}