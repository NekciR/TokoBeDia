using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handlers;
using TokoBeDia.Models;

namespace TokoBeDia.Controllers
{
    public class PaymentTypeController
    {

        public static string AddPaymentType(string name)
        {
            string alert = null;
            if (name == "")
            {
                alert = "Please insert payment type name!";

            }
            else if (name.Length < 3)
            {
                alert = "Minimal name length is 3!";

            }
            else if (!PaymentTypeHandler.IsNameUnique(name))
            {
                alert = "Payment type existed!";

            }
            else
            {
                PaymentTypeHandler.AddPaymentType(name);

            }
            return alert;
        }

        

        public static List<PaymentTypes> GetAllPaymentType()
        {
            return PaymentTypeHandler.GetAllPaymentType();
        }

        public static PaymentTypes DeleteById(int typeID)
        {
            if (PaymentTypeHandler.IsReferenced(typeID))
            {
                return null;
            }
            else
            {
                return PaymentTypeHandler.DeleteById(typeID);
            }
        }

        public static string UpdatePaymentType(int typeId, string name)
        {
            string alert = null;
            if (name == "")
            {
                alert = "Please insert payment type name!";

            }
            else if (name.Length < 3)
            {
                alert = "Minimal name length is 3!";

            }
            else if (!PaymentTypeHandler.IsUpdateNameUnique(typeId, name))
            {
                alert = "Payment type existed!";
            }
            else
            {
                PaymentTypeHandler.UpdatePaymentType(typeId,name);

            }
            return alert;
        }

        public static PaymentTypes GetById(int typeId)
        {
            return PaymentTypeHandler.GetById(typeId);
        }
    }
}