using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class PaymentTypeHandler
    {
        internal static bool IsNameUnique(string name)
        {
            PaymentTypes pt = PaymentTypeRepo.IsNameUnique(name);
            return pt == null ? true : false;
        }

        public static PaymentTypes AddPaymentType(string name)
        {
            return PaymentTypeRepo.AddPaymentType(name);
        }

        public static List<PaymentTypes> GetAllPaymentType()
        {
            return PaymentTypeRepo.GetAllPaymentType();
        }

        public static bool IsReferenced(int typeID)
        {
            HeaderTransactions ht = HeaderTransactionRepo.isReferenced(typeID);

            if (ht != null)
            {
                return true;
            }

            return false;
        }

        public static PaymentTypes DeleteById(int typeID)
        {
            PaymentTypes pt = PaymentTypeRepo.GetById(typeID);
            return PaymentTypeRepo.deletePaymentType(pt);
        }

        public static PaymentTypes GetById(int typeId)
        {
            return PaymentTypeRepo.GetById(typeId);
            
        }

        public static PaymentTypes UpdatePaymentType(int typeId, string name)
        {
            PaymentTypes pt = PaymentTypeRepo.GetById(typeId);
            return PaymentTypeRepo.UpdatePaymentType(pt, name);
        }

        public static bool IsUpdateNameUnique(int id, string name)
        {
            PaymentTypes pt = PaymentTypeRepo.IsNameUnique(name);
            if (pt == null || pt != null && pt.ID == id)
            {
                return true;
            }

            return false;
        }
    }
}