using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class RoleHandler
    {
        public static List<Roles> GetAllRole()
        {
            return RoleRepo.GetAllRole();
        }

        public static int getRoleById(int id)
        {
            return RoleRepo.getRoleById(id);
        }
    }
}