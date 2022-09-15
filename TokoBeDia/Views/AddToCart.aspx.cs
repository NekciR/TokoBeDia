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
    public partial class AddToCart : System.Web.UI.Page
    {
        private int productId;
        private Products product;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["productId"] == null || Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                productId = Int32.Parse(Request.QueryString["productId"]);
                product = ProductController.GetProductById(productId);
                LbProductName.Text = "Name: " + product.Name;
                LbProductPrice.Text = "Price: " + product.Price.ToString();
                LbProductStock.Text = "Stock: " + product.Stock.ToString();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string qty = TxtQty.Text;
       
            alertRed.Visible = false;
            string result = CartController.AddToCart(product, (Session["user"] as Users).ID, qty);

            if (result != null)
            {
                alertRed.Text = result;
                alertRed.Visible = true;
            }
            else
            {
                Response.Redirect("ViewProduct.aspx");
            }


        }
    }
}