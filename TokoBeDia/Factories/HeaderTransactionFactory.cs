using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class HeaderTransactionFactory
    {
        public static HeaderTransactions AddTransaction(int userId, int paymentId)
        {
            HeaderTransactions ht = new HeaderTransactions()
            {
                UserID = userId,
                PaymentTypeID = paymentId,
                Date = Convert.ToDateTime(DateTime.Now.ToString())
                

            };

            return ht;
        }
    }
}