using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.ViewModel
{
    public class TransactionViewModel
    {
        public string date { get; set; }
        public string payment { get; set; }
        public string product { get; set; }
        public int quantity { get; set; }
        public int subtotal { get; set; }
        public int userId { get; set; }
    }
}