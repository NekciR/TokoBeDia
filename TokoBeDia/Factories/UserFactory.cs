using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class UserFactory
    {

        public static Users RegisterUser(string email, string name, string password, string gender)
        {

            Users user = new Users()
            {
                Email = email,
                Name = name,
                Password = password,
                Gender = gender,
                RoleID = 2,
                Status = "Active"
            };

            return user;

        }

    }
}