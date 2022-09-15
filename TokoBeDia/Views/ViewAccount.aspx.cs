using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Models;

namespace TokoBeDia.Views
{
    public partial class ViewAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                LbEmail.Text = "Email :" + (Session["user"] as Users).Email;
                LbName.Text = "Name :" + (Session["user"] as Users).Name;
                LbGender.Text = "Gender :" + (Session["user"] as Users).Gender;
            }
        }

        protected void BtnUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAccount.aspx");
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}
