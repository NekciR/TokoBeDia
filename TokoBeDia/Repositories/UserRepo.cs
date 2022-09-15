using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factories;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class UserRepo
    {
        public static TokoBeDiaEntities db = new TokoBeDiaEntities();

        public static Users ChkUser(string email, string password)
        {
            Users user = (from u in db.Users where u.Email == email && u.Password == password select u).FirstOrDefault();

            return user;
        }

        public static Users GetById(int id)
        {
            Users user = (from u in db.Users where u.ID == id select u).FirstOrDefault();

            return user;
        }

        public static Users GetByEmail(string email)
        {
            Users user = (from u in db.Users where u.Email == email select u).FirstOrDefault();

            return user;
        }

        public static Users RegisterUser(string email, string name, string password, string gender)
        {
            Users user = UserFactory.RegisterUser(email, name, password, gender);

            db.Users.Add(user);
            db.SaveChanges();
            return user;

        }

        public static List<Users> GetAllUser()
        {
            List<Users> userList = (from u in db.Users select u).ToList();

            return userList;
        }

        public static Users updateUserRole(Users user, int roleId)
        {
            user.RoleID = roleId;
            db.SaveChanges();

            return user;
        }

        public static Users updateUserProfile(Users user, string email, string name, string gender)
        {
            user.Email = email;
            user.Name = name;
            user.Gender = gender;

            db.SaveChanges();

            return user;
        }

        public static Users updateUserStatus(Users user, string status)
        {
            user.Status = status;
            db.SaveChanges();

            return user;
        }

        public static Users UpdatePassword(Users user, string newPass)
        {
            
            user.Password = newPass;
            db.SaveChanges();

            return user;
        }


    }
}