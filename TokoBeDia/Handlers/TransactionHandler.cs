using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;
using TokoBeDia.ViewModel;

namespace TokoBeDia.Handlers
{
    public class TransactionHandler
    {
        public static List<TransactionViewModel> GetTransaction()
        {
            List<DetailTransactions> dtList = DetailTransactionRepo.GetAllDetail(); ;
            List<TransactionViewModel> tvmList = new List<TransactionViewModel>();

            foreach (DetailTransactions dt in dtList)
            {
                HeaderTransactions ht = HeaderTransactionRepo.GetTransactionByTransId(dt.TransactionID);
                PaymentTypes payment = PaymentTypeRepo.GetById(ht.PaymentTypeID);
                Products product = ProductRepo.getProductById(dt.ProductID);
                Users user = UserRepo.GetById(ht.UserID);

                tvmList.Add(new TransactionViewModel()
                {
                    date = ht.Date.ToShortDateString(),
                    payment = payment.Type,
                    product = product.Name,
                    quantity = dt.Quantity,
                    subtotal = dt.Quantity * product.Price,
                    userId = user.ID

                });
            }
            return tvmList;
        }

        public static List<TransactionViewModel> GetTransaction(int userId)
        {
            List<DetailTransactions> dtList = DetailTransactionRepo.GetDetailByUserId(userId); ;
            List<TransactionViewModel> tvmList = new List<TransactionViewModel>();

            foreach (DetailTransactions dt in dtList)
            {
                HeaderTransactions ht = HeaderTransactionRepo.GetTransactionByTransId(dt.TransactionID) ;
                PaymentTypes payment = PaymentTypeRepo.GetById(ht.PaymentTypeID);
                Products product = ProductRepo.getProductById(dt.ProductID);

                tvmList.Add(new TransactionViewModel()
                {
                    date = ht.Date.ToShortDateString(),
                    payment = payment.Type,
                    product = product.Name,
                    quantity = dt.Quantity,
                    subtotal = dt.Quantity * product.Price

                });
            }
            return tvmList;
        }

        public static TransactionReportDataSet GetReport()
        {
            TransactionReportDataSet dataset = new TransactionReportDataSet();

            TransactionReportDataSet.HeaderTransactionDataTable headerTable = dataset.HeaderTransaction;
            TransactionReportDataSet.DetailTransactionDataTable detailTable = dataset.DetailTransaction;


            List<HeaderTransactions> htList = HeaderTransactionRepo.GetAllTransaction();
            int count = 0;
            foreach (HeaderTransactions ht in htList)
            {
                
                Users user = UserRepo.GetById(ht.UserID);
                PaymentTypes payment = PaymentTypeRepo.GetById(ht.PaymentTypeID);
                DataRow headerRow = headerTable.NewRow();
                headerRow["ID"] = ht.ID;
                headerRow["Name"] = user.Name;
                headerRow["Email"] = user.Email;                     //Saya ngak pakai cara ht.Users.ID , karena terkadang bisa kena error null exception,
                headerRow["Gender"] = user.Gender;                  //Misal ht.Users.ID, sering null exception di bagian Usersnya, nanti di jalankan ulang bisa, kadang ga bisa lg
                headerRow["PaymentType"] = payment.Type;
                headerRow["Date"] = ht.Date.ToShortDateString();

                headerTable.Rows.Add(headerRow);

                
                foreach (DetailTransactions dt in ht.DetailTransactions)
                {
                    Products p = ProductRepo.getProductById(dt.ProductID);
                    DataRow detailRow = detailTable.NewRow();
                    detailRow["TransactionID"] = dt.TransactionID;
                    detailRow["Name"] = p.Name;
                    detailRow["Price"] = p.Price;
                    detailRow["Quantity"] = dt.Quantity;

                    detailTable.Rows.Add(detailRow);
                    
                }
                
            }

            return dataset;
        }
    }
}