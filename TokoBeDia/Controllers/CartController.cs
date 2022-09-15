using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TokoBeDia.Handlers;
using TokoBeDia.Models;
using TokoBeDia.ViewModel;

namespace TokoBeDia.Controllers
{
    public class CartController
    {
        public static string AddToCart(Products product,int userId, string qty)
        {
            int quantity = int.Parse(qty);
            Debug.WriteLine(quantity);
            string result = null;
            if (quantity <= 0)
            {
                result = "Quantity must be at least 1";
            } else if (quantity > product.Stock)
            {
                result = "Quantity exceed stock available!";
            }else
            {
                CartHandler.AddToCart(product, userId, quantity);
            }
            Debug.WriteLine(result);

            return result;
        }

        public static List<ProductCartViewModel> GetCartViewModelByUserId(int userId)
        {
            

            return CartHandler.GetCartByUserId(userId);
        }

        public static Carts DeleteCartById(int productId, int userId)
        {
            Debug.WriteLine("controller: " + userId);
            return CartHandler.DeleteCartById(productId, userId);
        }

        public static Carts GetCartByProductUserId(int productId, int userId)
        {
            return CartHandler.GetCartByProductUserId(productId, userId);
        }

        public static string UpdateQuantity(Products product, int userId, string qty)
        {
            int quantity = int.Parse(qty);
            if(quantity <= 0)
            {
                CartHandler.DeleteCartById(product.ID, userId);
                return null;
            }
            Carts cart = CartHandler.GetCartByProductUserId(product.ID, userId);
            int qtyDifference = System.Math.Abs(quantity - cart.Quantity);
            if(qtyDifference > product.Stock)
            {
                return "Item added exceed stock!";
            }else if(quantity == cart.Quantity)
            {
                return null;
            }
            else
            {
                CartHandler.UpdateQuantity(product, userId, quantity);
            }
            

            return null;
        }

        public static void CheckOut(int userId, int value)
        {
            CartHandler.CheckOut(userId, value);
        }
    }
}