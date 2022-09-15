using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TokoBeDia.Handlers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;
using TokoBeDia.ViewModel;

namespace TokoBeDia.Controllers
{
    public class TransactionController
    {
        public static List<TransactionViewModel> GetTransaction()
        {
            List<TransactionViewModel> dtList = TransactionHandler.GetTransaction();
            return dtList;
        }

        public static List<TransactionViewModel> GetTransaction(int userId)
        {
            List<TransactionViewModel> dtList = TransactionHandler.GetTransaction(userId);
            return dtList;
        }

        public static TransactionReportDataSet getReportData()
        {
            return TransactionHandler.GetReport();
        }
    }
}