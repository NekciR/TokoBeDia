using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class ProductHandler
    {
        public static Products AddProduct(int typeId, string name, int price, int stock)
        {
            return ProductRepo.AddProduct(typeId, name, price, stock);
        }

        public static int ProductCount()
        {
            return ProductRepo.ProductCount();
        }

        public static Products GetProductById(int id)
        {
            return ProductRepo.getProductById(id);
        }

        public static List<Products> GetAllProduct()
        {
            return ProductRepo.getAllProduct();
        }

        public static IEnumerable<Products> RandomProductList(int count)
        {
            Random rand = new Random();
            List<Products> productList = ProductRepo.getAllProduct();
            IEnumerable<Products> randomizedList = (from pl in productList orderby rand.Next() select pl).Take(count);

            return randomizedList;
        }

        public static bool IsReferenced(int productId)
        {
            DetailTransactions detail = DetailTransactionRepo.isReferenced(productId);

            if (detail != null)
            {
                return true;
            }

            return false;
        }

        public static Products DeleteProductById(int productId)
        {
            Products product = ProductRepo.getProductById(productId);
            return ProductRepo.deleteProduct(product);

        }

        public static Products UpdateProduct(int id, int typeId, string name, int price, int stock)
        {
            Products product = ProductRepo.getProductById(id);
            return ProductRepo.UpdateProduct(product, typeId, name, price, stock);
        }



    }
}