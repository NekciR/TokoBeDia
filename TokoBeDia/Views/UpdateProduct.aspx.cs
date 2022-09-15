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
    public partial class UpdateProduct : System.Web.UI.Page
    {
        int productId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["productId"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            productId = Int32.Parse(Request.QueryString["productId"]);
            if (!IsPostBack)
            {
                bindDdl();
                Products product = ProductController.GetProductById(productId);
                TxtProductName.Text = product.Name;
                ddlProductType.SelectedValue = product.ProductTypeID.ToString();
                TxtPrice.Text = product.Price.ToString();
                TxtStock.Text = product.Stock.ToString();
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TxtProductName.Text;
            string price = TxtPrice.Text;
            string stock = TxtStock.Text;
            int typeId = int.Parse(ddlProductType.SelectedValue);
            Alert.Visible = false;
            string result = ProductController.UpdateProduct(productId, typeId, name, price, stock);

            if (result != null)
            {
                Alert.Text = result;
                Alert.Visible = true;
            }
            else
            {            
                Response.Redirect("ViewProduct.aspx");
            }


        }

        protected void bindDdl()
        {
            List<ProductTypes> typeList = ProductTypeController.GetAllProductType();
            ddlProductType.DataSource = typeList;
            ddlProductType.DataTextField = "Name";
            ddlProductType.DataValueField = "ID";
            ddlProductType.DataBind();
        }
    }
}