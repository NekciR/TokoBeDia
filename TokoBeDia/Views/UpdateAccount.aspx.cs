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
    public partial class UpdateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    TxtEmail.Text = (Session["user"] as Users).Email;
                    TxtName.Text = (Session["user"] as Users).Name;
                    if ((Session["user"] as Users).Gender == "Male")
                    {
                        RbMale.Checked = true;
                    }
                    else
                    {
                        RbFemale.Checked = true;
                    }
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LbAlert.Visible = false;
            int id = (Session["user"] as Users).ID;
            string email = TxtEmail.Text;
            string name = TxtName.Text;
            string gender = RbMale.Checked == true ? "Male" : "Female";
            string result = UserController.UpdateUserProfile(email, name, id, gender);
            LbAlert.Visible = false;

            if (result != null)
            {
                LbAlert.Text = result;
                LbAlert.Visible = true;
            }else
            {
                Session["user"] = UserController.ReUpdateSessionUser(id);
                Response.Redirect("ViewAccount.aspx");
            }


        }
    }
}