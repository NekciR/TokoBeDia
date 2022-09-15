using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class ProductTypeFactory
    {
        public static ProductTypes AddProductType(string name, string desc)
        {

            ProductTypes productType = new ProductTypes()
            {
                Name = name,
                Description = desc
            };

            return productType;

        }
    }
}