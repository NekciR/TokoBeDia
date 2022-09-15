using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class CartFactory
    {
        public static Carts AddToCart(int productId, int userId, int qty)
        {
            Carts cart = new Carts()
            {
                UserID = userId,
                ProductID = productId,
                Quantity = qty

            };

            return cart;
        }
    }
}