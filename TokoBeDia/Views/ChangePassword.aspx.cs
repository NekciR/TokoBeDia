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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("home.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Users user = Session["user"] as Users;
            string old = TxtOldPassword.Text;
            string newPass = TxtNewPass.Text;
            string confirm = TxtConfirm.Text;
            Alert.Visible = false;
            string result = UserController.UpdatePassword(user, old, newPass, confirm);


            if(result != null)
            {
                Alert.Text = result;
                Alert.Visible = true;
            }
            else
            {
                Session["user"] = UserController.ReUpdateSessionUser((Session["user"] as Users).ID);
                Response.Redirect("ViewAccount.aspx");
            }

            



        }
    }
}