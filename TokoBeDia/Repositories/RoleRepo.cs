using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class RoleRepo
    {

        public static TokoBeDiaEntities db = new TokoBeDiaEntities();

        public static List<Roles> GetAllRole()
        {
            List<Roles> roleList = (from r in db.Roles select r).ToList();


            return roleList;
        }

        public static int getRoleById(int id)
        {
            int result = (from r in db.Roles join u in db.Users on r.ID equals u.RoleID where u.ID == id select r.ID).FirstOrDefault();

            return result;
        }
    }
}