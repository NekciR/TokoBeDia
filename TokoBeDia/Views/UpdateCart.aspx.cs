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
    public partial class UpdateCart : System.Web.UI.Page
    {
        private int productId;
        private Products product;
        private int userId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["productId"] == null || Session["user"] == null || (Session["user"] as Users).Roles.Name == "Administrator")
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                productId = Int32.Parse(Request.QueryString["productId"]);
                userId = (Session["user"] as Users).ID;
                product = ProductController.GetProductById(productId);
                Carts cart = CartController.GetCartByProductUserId(productId, userId);
                if (!IsPostBack)
                {

                    LbProductName.Text = "Name: " + product.Name;
                    LbProductPrice.Text = "Price: " + product.Price.ToString();
                    LbProductStock.Text = "Stock: " + product.Stock.ToString();
                    TxtQty.Text = cart.Quantity.ToString();
                }
                
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string qty = TxtQty.Text;


            alertRed.Visible = false;
            string result = CartController.UpdateQuantity(product, userId, qty);

            if (result != null)
            {
                alertRed.Text = result;
                alertRed.Visible = true;
            }
            else
            {
                Response.Redirect("ViewCart.aspx");
            }


        }
    }
}
