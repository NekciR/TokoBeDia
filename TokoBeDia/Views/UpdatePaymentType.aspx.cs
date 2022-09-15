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
    public partial class UpdatePaymentType : System.Web.UI.Page
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

                PaymentTypes paymentType = PaymentTypeController.GetById(typeId);
                TxtTypeName.Text = paymentType.Type;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TxtTypeName.Text;
            Alert.Visible = false;
            string result = PaymentTypeController.UpdatePaymentType(typeId, name);

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
    }
}