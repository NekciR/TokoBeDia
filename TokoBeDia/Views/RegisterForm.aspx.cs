using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repositories;
using System.Text.RegularExpressions;
using TokoBeDia.Controllers;

namespace TokoBeDia.Views
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string name = TxtName.Text;
            string password = TxtPassword.Text;
            string confirm = TxtConfirm.Text;

            string resultEmail = UserController.isValidEmail(email);
            string resultName = UserController.isValidName(name);
            string resultPassword = UserController.isValidPassword(password);
            string resultConfirm = UserController.isValidConfirm(password, confirm);
            string resultGender = UserController.isGenderChecked(RbMale, RbFemale);
            NameAlert.Visible = false;
            GenderAlert.Visible = false;
            PasswordAlert.Visible = false;
            ConfirmAlert.Visible = false;
            EmailAlert.Visible = false;

            if (resultEmail != null || resultName != null || resultPassword != null || resultConfirm != null || resultGender != null)
            {
                if (resultEmail != null)
                {
                    EmailAlert.Text = resultEmail;
                    EmailAlert.Visible = true;
                }
                if (resultName != null)
                {
                    NameAlert.Text = resultName;
                    NameAlert.Visible = true;
                }
                if (resultPassword != null)
                {
                    PasswordAlert.Text = resultPassword;
                    PasswordAlert.Visible = true;
                }
                if (resultConfirm != null)
                {
                    ConfirmAlert.Text = resultConfirm;
                    ConfirmAlert.Visible = true;
                }
                if (resultGender != null)
                {
                    GenderAlert.Text = resultGender;
                    GenderAlert.Visible = true;
                }
            }
            else
            {
                string gender = RbMale.Checked ? "Male" : "Female";
                UserController.RegisterUser(email, name, password, gender);
                Response.Redirect("LoginForm.aspx");

            }

            


            //if (isValidEmail(email) && isValidName(name) && isValidPassword(password, confirm) && isGenderChecked())
            //{
            //    string gender = RbMale.Checked ? "Male" : "Female";
            //    UserRepo.RegisterUser(email, name, password, gender);
            //    Response.Redirect("LoginForm.aspx");
            //}


        }

        //protected bool isValidEmail(string email)
        //{
        //    string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        //    if (email == "")
        //    {
        //        EmailAlert.Text = "Can't be empty!";
        //        EmailAlert.Visible = true;
        //        return false;
        //    }
        //    else if (!Regex.IsMatch(email, pattern))
        //    {
        //        EmailAlert.Text = "Invalid Email!";
        //        EmailAlert.Visible = true;
        //        return false;
        //    }
        //    else if (!UserRepo.isEmailUnique(email))
        //    {
        //        EmailAlert.Text = "Email used!";
        //        EmailAlert.Visible = true;
        //        return false;
        //    }

        //    EmailAlert.Visible = false;
        //    return true;

        //}

        //protected bool isValidName(string name)
        //{
        //    if (name == "")
        //    {
        //        NameAlert.Text = "Can't be empty!";
        //        NameAlert.Visible = true;
        //        return false;

        //    }
        //    NameAlert.Visible = false;
        //    return true;
        //}

        //protected bool isValidPassword(string password, string confirm)
        //{
        //    if (password == "")
        //    {
        //        PasswordAlert.Text = "Can't be empty!";
        //        PasswordAlert.Visible = true;
        //        return false;

        //    }
        //    else if (confirm == "")
        //    {
        //        PasswordAlert.Visible = false;
        //        ConfirmAlert.Text = "Can't be empty!";
        //        ConfirmAlert.Visible = true;
        //        return false;
        //    }
        //    else if (confirm != password)
        //    {
        //        PasswordAlert.Visible = false;
        //        ConfirmAlert.Text = "Password not same!";
        //        ConfirmAlert.Visible = true;
        //        return false;
        //    }


        //    PasswordAlert.Visible = false;
        //    ConfirmAlert.Visible = false;
        //    return true;
        //}

        //protected bool isGenderChecked()
        //{
        //    if (RbMale.Checked == false && RbFemale.Checked == false)
        //    {
        //        GenderAlert.Text = "Select your gender!";
        //        GenderAlert.Visible = true;
        //        return false;

        //    }

        //    GenderAlert.Visible = false;
        //    return true;
        //}
    }
}