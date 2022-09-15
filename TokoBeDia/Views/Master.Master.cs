using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;

namespace TokoBeDia.Views
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LbYearNow.Text = DateTime.Now.Year.ToString();
            if (Session["user"] != null)
            {
                if((Session["user"] as Users).Roles.Name == "Member")
                {
                    ViewCart.Visible = true;
                }else
                {
                    ViewCart.Visible = false;
                }
                Register.Visible = false;
                Login.Visible = false;
                Account.Visible = true;
                Logout.Visible = true;
                ViewTransaction.Visible = true;
            }
            else
            {
                Register.Visible = true;
                Login.Visible = true;
                Account.Visible = false;
                Logout.Visible = false;
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Cookies["email"].Expires = DateTime.Now.AddHours(-1);
            Response.Cookies["password"].Expires = DateTime.Now.AddHours(-1);
            Response.Redirect("LoginForm.aspx");
        }
    }
}