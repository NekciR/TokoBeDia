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
    public partial class UpdateProductType : System.Web.UI.Page
    {
        int typeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["typeId"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            typeId = Int32.Parse(Request.QueryString["typeId"]);
            if (!IsPostBack)
            {
                
                ProductTypes productType = ProductTypeController.GetById(typeId);
                TxtTypeName.Text = productType.Name;
                TxtTypeDesc.Text = productType.Description;
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TxtTypeName.Text;
            string desc = TxtTypeDesc.Text;
            Debug.WriteLine(name);
            Alert.Visible = false;
            string result = ProductTypeController.UpdateProductType(typeId, name, desc);

            if (result != null)
            {
                Alert.Text = result;
                Alert.Visible = true;
            }
            else
            {
                Response.Redirect("ViewProductType.aspx");
            }
        }


    }
}