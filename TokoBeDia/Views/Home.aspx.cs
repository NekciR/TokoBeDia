using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controllers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Views
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
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

            if (!IsPostBack)
            {


                BindGridList();
            }

        }


        protected void BindGridList()
        {
            int pCount = ProductController.ProductCount();
            GvHomeProduct.DataSource = ProductController.RandomProductList(pCount);

            GvHomeProduct.DataBind();
        }

        protected void GvHomeProduct_RowCreated(object sender, GridViewRowEventArgs e)
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
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = true;
                    e.Row.Cells[6].Visible = true;
                    e.Row.Cells[0].Visible = true;
                }
                else
                {
                    e.Row.Cells[4].Visible = true;
                    e.Row.Cells[0].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[5].Visible = false;
                }

            }

        }


        protected bool isAdmin()
        {
            return (Session["user"] as Users).Roles.Name == "Administrator" ? true : false;
        }

        protected void GvHomeProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int productId = Int32.Parse(GvHomeProduct.Rows[rowIndex].Cells[0].Text);
            alertRed.Visible = false;
            alertGreen.Visible = false;
            if (ProductController.isReferenced(productId))
            {
                alertRed.Text = "Delete failed, product is referenced by certain transaction!";
                alertRed.Visible = true;
                return;
            }
            else
            {
                Products pt = ProductController.DeleteProductById(productId);
                BindGridList();
                alertGreen.Text = "Product type id: " + pt.ID + " Deleted!";
                alertGreen.Visible = true;


            }
        }

        protected void GvHomeProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string productId = GvHomeProduct.Rows[rowIndex].Cells[0].Text;

            Response.Redirect("UpdateProduct.aspx?productId=" + productId);


        }

        protected void GvHomeProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            
            if (e.CommandName == "AddToCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string productId = GvHomeProduct.Rows[rowIndex].Cells[0].Text;
                Response.Redirect("AddToCart.aspx?productId=" + productId);

            }
        }
    }
}