using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.ViewModel
{
    public class ProductCartViewModel
    {
        public int productId { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int subtotal { get; set; }
    }
}