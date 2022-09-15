using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handlers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Controllers
{
    public class ProductController
    {
        public static string InsertProduct(int typeId, string name, string price, string stock)
        {
            string alert = null;
            int tempPrice = 0;
            int tempStock = 0;
            if (name == "" || price == "" || stock == "")
            {
                alert = "Please insert all field!";

            }
            else if (!int.TryParse(price, out tempPrice) || !int.TryParse(stock, out tempStock))
            {
                alert = "Price and Stock accept number input only!";

            }
            else if (tempStock < 1)
            {
                alert = "Stock must be 1 or more";

            }
            else if (tempPrice < 1000 || tempPrice % 1000 != 0)
            {
                alert = "Price must be above 1000 and multiply of 1000";

            }
            else
            {
                ProductHandler.AddProduct(typeId, name, tempPrice, tempStock);
            }

            return alert;
        }

        public static int ProductCount()
        {
            return ProductHandler.ProductCount();
        }

        public static IEnumerable<Products> RandomProductList(int productCount)
        {
            if (productCount < 5)
            {
                return ProductHandler.RandomProductList(productCount);
            }
            else
            {
                return ProductHandler.RandomProductList(5);
            }
        }

        public static bool isReferenced(int productId)
        {
            return ProductHandler.IsReferenced(productId);

        }

        public static Products GetProductById(int productId)
        {
            return ProductRepo.getProductById(productId);
        }

        public static string UpdateProduct(int productId, int typeId, string name, string price, string stock)
        {
            string alert = null;
            int tempPrice = 0;
            int tempStock = 0;

            if (name == "" || price == "" || stock == "")
            {
                alert = "Please insert all field!";

            }
            else if (!int.TryParse(price, out tempPrice) || !int.TryParse(stock, out tempStock))
            {
                alert = "Price and Stock accept number input only!";

            }
            else if (tempStock < 1)
            {
                alert = "Stock must be 1 or more";

            }
            else if (tempPrice < 1000 || tempPrice % 1000 != 0)
            {
                alert = "Price must be above 1000 and multiply of 1000";

            }
            else
            {
                ProductHandler.UpdateProduct(productId, typeId, name, tempPrice, tempStock);
            }

            return alert;
        }

        public static List<Products> getAllProduct()
        {
            return ProductHandler.GetAllProduct();
        }

        public static Products DeleteProductById(int productId)
        {
            if (ProductHandler.IsReferenced(productId))
            {
                return null;
            }
            else
            {
                return ProductHandler.DeleteProductById(productId);
            }
        }



    }
}