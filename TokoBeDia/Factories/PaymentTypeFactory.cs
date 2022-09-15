using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class PaymentTypeFactory
    {
        public static PaymentTypes AddProductType(string name)
        {
            PaymentTypes paymentType = new PaymentTypes()
            {
                Type = name,
                
            };

            return paymentType;
        }
    }
}