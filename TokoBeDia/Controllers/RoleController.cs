using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handlers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Controllers
{
    public class RoleController
    {
        public static List<Roles> GetAllRole()
        {
            return RoleHandler.GetAllRole();
        }

        public static int getRoleById(int id)
        {
            return RoleHandler.getRoleById(id);
        }
    }
}