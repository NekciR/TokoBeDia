using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class ProductFactory
    {
       public static Products getProduct(int id, int typeId, string name, int price, int stock)
        {
            Products product = new Products()
            {
                ID = id,
                ProductTypeID = typeId,
                Name = name,
                Price = price,
                Stock = stock
          
            };

            return product;

        }

        public static Products AddProduct(int typeId, string name, int price, int stock)
        {

            Products product = new Products()
            {
                Name = name,
                ProductTypeID = typeId,
                Price = price,
                Stock = stock
              
            };

            return product;

        }


    }
}