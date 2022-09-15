using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factories;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class PaymentTypeRepo
    {
        public static TokoBeDiaEntities db = new TokoBeDiaEntities();

        public static PaymentTypes AddPaymentType(string name)
        {
            PaymentTypes paymentType = PaymentTypeFactory.AddProductType(name);

            db.PaymentTypes.Add(paymentType);
            db.SaveChanges();

            return paymentType;
        }

        public static PaymentTypes IsNameUnique(string name)
        {
            PaymentTypes paymentType = (from pt in db.PaymentTypes where pt.Type == name select pt).FirstOrDefault();
            return paymentType;
        }

        public static List<PaymentTypes> GetAllPaymentType()
        {
            return (from pt in db.PaymentTypes select pt).ToList();
           
        }

        public static PaymentTypes GetById(int typeID)
        {
            return (from pt in db.PaymentTypes where pt.ID == typeID select pt).FirstOrDefault();
        }

        public static PaymentTypes deletePaymentType(PaymentTypes paymentType)
        {
            db.PaymentTypes.Remove(paymentType);
            db.SaveChanges();


            return paymentType;
        }

        public static PaymentTypes UpdatePaymentType(PaymentTypes pt, string name)
        {
            pt.Type = name;
            db.SaveChanges();

            return pt;
        }
    }
}