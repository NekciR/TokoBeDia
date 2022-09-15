using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factories;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class DetailTransactionRepo
    {
        public static TokoBeDiaEntities db = new TokoBeDiaEntities();
        public static DetailTransactions isReferenced(int productId)
        {
            return (from dt in db.DetailTransactions where dt.ProductID == productId select dt).FirstOrDefault();
        }

        public static DetailTransactions AddDetail(int iD, int productID, int quantity)
        {
            DetailTransactions dt = DetailTransactionFactory.AddDetail(iD, productID, quantity);
            db.DetailTransactions.Add(dt);
            db.SaveChanges();

            return dt;
        }

        public static List<DetailTransactions> GetDetailByUserId(int userId)
        {
            return (from dt in db.DetailTransactions join ht in db.HeaderTransactions on dt.TransactionID equals ht.ID where ht.UserID == userId select dt).ToList();
        }

        public static List<DetailTransactions> GetAllDetail()
        {
            return (from dt in db.DetailTransactions select dt).ToList();
        }

        public static List<DetailTransactions> GetDetailByTransactionId(int iD)
        {
            return (from dt in db.DetailTransactions where dt.TransactionID == iD select dt).ToList();
        }
    }
}