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
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDdl();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TxtProductName.Text;
            string price = TxtPrice.Text;
            string stock = TxtStock.Text;
            int typeId = int.Parse(ddlProductType.SelectedValue);
            Alert.Visible = false;
            string result = ProductController.InsertProduct(typeId, name, price, stock);

            if(result != null)
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