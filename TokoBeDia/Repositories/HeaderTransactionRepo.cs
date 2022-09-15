using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factories;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class HeaderTransactionRepo
    {
        public static TokoBeDiaEntities db = new TokoBeDiaEntities();

        public static HeaderTransactions isReferenced(int id)
        {
            return (from ht in db.HeaderTransactions where ht.PaymentTypeID == id select ht).FirstOrDefault();
        }

        public static HeaderTransactions AddTransaction(int userId, int paymentTypeId)
        {
            HeaderTransactions ht = HeaderTransactionFactory.AddTransaction(userId, paymentTypeId);
            db.HeaderTransactions.Add(ht);
            db.SaveChanges();

            return ht;
        }

        public static List<HeaderTransactions> GetTransactionByUserId(int userId)
        {
            return (from ht in db.HeaderTransactions where ht.UserID == userId select ht).ToList();
        }

        public static HeaderTransactions GetTransactionByTransId(int transactionID)
        {
            return (from ht in db.HeaderTransactions where ht.ID == transactionID select ht).FirstOrDefault();
        }

        public static List<HeaderTransactions> GetAllTransaction()
        {
            return (from ht in db.HeaderTransactions select ht).ToList();
        }
    }
}