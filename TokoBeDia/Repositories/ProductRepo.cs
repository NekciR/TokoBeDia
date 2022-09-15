using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factories;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class ProductRepo
    {
        public static TokoBeDiaEntities db = new TokoBeDiaEntities();
        public static int ProductCount()
        {
            int count = (from p in db.Products select p).Count();
            return count;

        }

        public static Products getProductById(int id)
        {
            Products product = (from p in db.Products where p.ID == id select p).FirstOrDefault();

            return product;
        }

        public static List<Products> getAllProduct()
        {
            List<Products> productList = (from p in db.Products select p).ToList();

            return productList;

        }

        public static Products AddProduct(int typeId, string name, int price, int stock)
        {
            Products product = ProductFactory.AddProduct(typeId, name, price, stock);

            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }

        public static Products deleteProduct(Products product)
        {
            db.Products.Remove(product);
            db.SaveChanges();


            return product;
        }

        public static Products UpdateProduct(Products product, int typeId, string name, int price, int stock)
        {
            product.Name = name;
            product.Price = price;
            product.Stock = stock;
            product.ProductTypeID = typeId;
            db.SaveChanges();

            return product;
        }

        public static Products isReferenced(int id)
        {
            Products product = (from p in db.Products where p.ProductTypeID == id select p).FirstOrDefault();

            return product;
        }

        public static Products updateStock(Products product, int stock)
        {
            product.Stock = product.Stock + stock;
            db.SaveChanges();

            return product;
        }


    }
}