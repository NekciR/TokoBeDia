using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class ProductTypeHandler
    {
      public static bool IsNameUnique(string name)
        {
            ProductTypes pt = ProductTypeRepo.IsNameUnique(name);
            return pt == null ? true : false;
        }
        
        public static bool IsUpdateNameUnique(int id, string name)
        {
            ProductTypes pt = ProductTypeRepo.IsNameUnique(name);
            if (pt == null || pt != null && pt.ID == id)
            {
                return true;
            }

            return false;
        } 

       public static ProductTypes AddProductType(string name, string desc)
        {
            return ProductTypeRepo.AddProductType(name, desc);
        }

        public static List<ProductTypes> GetAllProductType()
        {
            return ProductTypeRepo.GetAllProductType();
        }

        public static ProductTypes DeleteById(int id)
        {
            ProductTypes pt = ProductTypeRepo.getProductTypeById(id);
            return ProductTypeRepo.deleteProductType(pt);
        }

        public static bool IsReferenced(int id)
        {
            Products p = ProductRepo.isReferenced(id);

            if (p != null)
            {
                return true;
            }

            return false;
        }

        public static ProductTypes GetById(int id)
        {
            return ProductTypeRepo.getProductTypeById(id);

        }

        public static ProductTypes UpdateProductType(int id,string name,string desc)
        {
            ProductTypes pt  = ProductTypeRepo.getProductTypeById(id);
            return ProductTypeRepo.UpdateProductType(pt, name, desc);
        }



    }
}