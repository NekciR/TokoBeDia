using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handlers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Controllers
{
    public class ProductTypeController
    {
        public static List<ProductTypes> GetAllProductType()
        {
            return ProductTypeHandler.GetAllProductType();
        }

        public static string AddProductType(string name, string desc)
        {
            string alert = null;
            if (name == "" || desc == "")
            {
                alert = "Please insert all field!";
                
            }
            else if (name.Length < 5)
            {
                alert = "Minimal name length is 5!";
                
            }
            else if (!ProductTypeHandler.IsNameUnique(name))
            {
                alert = "Product type existed!";
                
            }
            else
            {
                ProductTypeHandler.AddProductType(name, desc);
                
            }
            return alert;
        }

        public static ProductTypes GetById(int typeId)
        {
            return ProductTypeHandler.GetById(typeId);
        }

        public static string UpdateProductType(int typeId, string name, string desc)
        {
            string alert = null;
            if (name == "" || desc == "")
            {
                alert = "Please insert all field!";

            }
            else if (name.Length < 5)
            {
                alert = "Minimal name length is 5!";

            }
            else if (!ProductTypeHandler.IsUpdateNameUnique(typeId,name))
            {
                alert = "Product type existed!";

            }
            else
            {
                ProductTypeHandler.UpdateProductType(typeId, name, desc);

            }
            return alert;
        }

        public static ProductTypes DeleteById(int typeId)
        {
            if (ProductTypeHandler.IsReferenced(typeId)){
                return null;
            }else
            {
                return ProductTypeHandler.DeleteById(typeId);
            }
        }
    }
}