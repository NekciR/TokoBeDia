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
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
                if (Request.Cookies["Email"] != null && Request.Cookies["Password"] != null)
                {
                    TxtEmail.Text = Request.Cookies["Email"].Value;
                    TxtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    CbRememberMe.Checked = true;
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;

            if (email == "" || password == "")
            {
                AlertFailLogin.Text = "Email/Password can't be empty!";
                AlertFailLogin.Visible = true;
                return;
            }

            Users user = UserController.ChkUser(email, password);




            if (user != null)
            {
                if (user.Status == "Banned")
                {
                    AlertFailLogin.Text = "Account banned, please contact us!";
                    AlertFailLogin.Visible = true;
                    return;
                }

                Session["user"] = user;
          
                if (CbRememberMe.Checked)
                {
                    Response.Cookies["Email"].Expires = DateTime.Now.AddDays(60);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(60);
                    
                }
                else
                {
                    Response.Cookies["Email"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                    

                }

                Response.Cookies["Email"].Value = TxtEmail.Text.Trim();
                Response.Cookies["Password"].Value = TxtPassword.Text.Trim();
                

                Response.Redirect("Home.aspx");

            }
            else
            {
                AlertFailLogin.Text = "No Such Account!";
                AlertFailLogin.Visible = true;
            }
        }
    }
}