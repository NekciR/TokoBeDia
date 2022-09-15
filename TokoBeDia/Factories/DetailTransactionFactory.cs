using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class DetailTransactionFactory
    {
        public static DetailTransactions AddDetail(int transactionId, int productId, int qty)
        {
            DetailTransactions dt = new DetailTransactions()
            {
                TransactionID = transactionId,
                ProductID = productId,
                Quantity = qty

            };

            return dt;
        }
    }
}