using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TokoBeDia.Factories;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class ProductTypeRepo
    {
        public static TokoBeDiaEntities db = new TokoBeDiaEntities();

        public static ProductTypes IsNameUnique(string name)
        {
            ProductTypes productType = (from pt in db.ProductTypes where pt.Name == name select pt).FirstOrDefault();
            return productType;
        }

        public static ProductTypes AddProductType(string name, string desc)
        {
            ProductTypes productType = ProductTypeFactory.AddProductType(name, desc);

            db.ProductTypes.Add(productType);
            db.SaveChanges();

            return productType;

            
        }

        public static List<ProductTypes> GetAllProductType()
        {
            List<ProductTypes> result = (from pt in db.ProductTypes select pt).ToList();


            return result;
        }

        public static ProductTypes deleteProductType(ProductTypes productType)
        {
            db.ProductTypes.Remove(productType);
            db.SaveChanges();


            return productType;

        }

        public static ProductTypes getProductTypeById(int id)
        {
            return (from pt in db.ProductTypes where pt.ID == id select pt).FirstOrDefault();
        }

        public static ProductTypes UpdateProductType(ProductTypes pt, string name, string desc)
        {
            pt.Name = name;
            pt.Description = desc;
            db.SaveChanges();

            return pt;
        }
    }
}