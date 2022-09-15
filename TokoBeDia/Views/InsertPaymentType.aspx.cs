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
    public partial class InsertPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                if (!isAdmin())
                {
                    Response.Redirect("home.aspx");
                }

            }
            else
            {
                Response.Redirect("home.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TxtTypeName.Text;
            Alert.Visible = false;
            string result = PaymentTypeController.AddPaymentType(name);

            if (result != null)
            {
                Alert.Text = result;
                Alert.Visible = true;
            }
            else
            {
                Response.Redirect("ViewPaymentType.aspx");
            }


        }

        protected bool isAdmin()
        {
            return (Session["user"] as Users).Roles.Name == "Administrator" ? true : false;
        }
    }
}