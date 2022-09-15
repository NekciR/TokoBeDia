using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Handlers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Controllers
{
    public class UserController
    {

        public static string UpdatePassword(Users user, string old, string newPass, string confirm)
        {
            string result = null;

            if (old == "" || newPass == "" || confirm == "")
            {
                result = "Please fill all field!";               
            }
            else if (newPass.Length < 5)
            {

                result = "Password must be >= 5 characters!";
                
            }
            else if (newPass != confirm)
            {
                result = "Password confirmation not match!";
                
            }
            else if (!UserHandler.IsOldPasswordMatch(user.ID, old))
            {
                result = "Wrong old password";
            }else
            {
                UserHandler.UpdatePassword(user.ID,newPass);
            }

            return result;
        }

        public static Users ReUpdateSessionUser(int id)
        {
            return UserHandler.GetById(id);
        }

        public static Users ChkUser(string email, string password)
        {
            return UserHandler.ChkUser(email, password);
        }

        public static Users RegisterUser(string email, string name, string password, string gender)
        {
            return UserHandler.RegisterUser(email, name, password, gender); ;
        }

        public static string UpdateUserProfile( string email, string name, int id,string gender)
        {
            string result = null; 
            if (email == "" || name == "")
            {
                result = "Field can't be empty!";
                
            }
            else if (!UserHandler.IsUpdateEmailUnique(id, email))
            {
                result = "Email existed, please use other email!";

            }else
            {
                UserHandler.UpdateUserProfile(id, email, name, gender);
            }


            return result;
        }

        public static List<Users> GetAllUser()
        {
            return UserHandler.GetAllUser();
        }





        public static string isValidEmail(string email)
        {
            string result = null;
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (email == "")
            {
                result = "Can't be empty!";
            }
            else if (!Regex.IsMatch(email, pattern))
            {
                result = "Invalid Email!";
            }
            else if (!UserHandler.IsEmailUnique(email))
            {
                result = "Email used!";
            }


            return result;

        }

        public static string isValidName(string name)
        {
            string result = null;
            if (name == "")
            {
                result = "Can't be empty!";
            }

            return result;
        }

        public static string isValidPassword(string password)
        {
            string result = null;
            if (password == "")
            {
                result = "Can't be empty!";

            }

            return result;

        }

        public static string isValidConfirm(string password, string confirm)
        {
            string result = null;
            if (confirm == "")
            {
                result = "Can't be empty!";

            }
            else if (confirm != password)
            {

                result = "Password not same!";

            }

            return result;
        }

        public static string isGenderChecked(RadioButton RbMale, RadioButton RbFemale)
        {
            string result = null;
            if (RbMale.Checked == false && RbFemale.Checked == false)
            {
                result = "Select your gender!";
            }
            return result;
        }

        public static string GetUserStatusById(int id)
        {
            return UserHandler.GetById(id).Status;
        }

        public static Users UpdateUserRole(int userId, int roleId)
        {
            return UserHandler.UpdateUserRole(userId, roleId);
        }

        public static Users UpdateUserStatus(int userId, string status)
        {
            return UserHandler.UpdateUserStatus(userId, status);
        }


    }
}