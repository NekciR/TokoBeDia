using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class UserHandler
    {
        public static Users ChkUser(string email, string password)
        {
            return UserRepo.ChkUser(email, password);

        }

        public static Users GetById(int id)
        {
            return UserRepo.GetById(id);
        }

        public static bool IsEmailUnique(string email)
        {
            Users u = UserRepo.GetByEmail(email);
            return u == null ? true : false;
        }

        public static Users RegisterUser(string email, string name, string password, string gender)
        {
            return UserRepo.RegisterUser(email, name, password, gender);
        }

        public static Users UpdateUserRole(int userId, int roleId)
        {
            Users user = UserRepo.GetById(userId);
            return UserRepo.updateUserRole(user, roleId);
        }

        public static Users UpdateUserProfile(int userId, string email, string name, string gender)
        {
            Users user = UserRepo.GetById(userId);
            return UserRepo.updateUserProfile(user, email,name,gender);
        }

        public static Users UpdateUserStatus(int userId, string status)
        {
            Users user = UserRepo.GetById(userId);
            return UserRepo.updateUserStatus(user, status);
        }

        public static string getUserStatusById(int id)
        {
            string status = UserRepo.GetById(id).Status;
            return status;
        }

        public static bool IsUpdateEmailUnique(int id, string email)
        {
            Users user = UserRepo.GetByEmail(email);
            if (user == null || user != null && user.ID == id)
            {
                return true;
            }

            return false;
        }

        public static bool IsOldPasswordMatch(int id, string password)
        {
            Users user = UserRepo.GetById(id);

            return user.Password == password;

        }

        public static Users UpdatePassword(int id, string newPass)
        {
            Users user = UserRepo.GetById(id);
            return UserRepo.UpdatePassword(user,newPass);
        }

        public static List<Users> GetAllUser()
        {
            return UserRepo.GetAllUser();
        }


    }
}