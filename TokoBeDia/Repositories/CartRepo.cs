using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factories;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class CartRepo
    {
        public static TokoBeDiaEntities db = new TokoBeDiaEntities();
        public static Carts InsertCart(int productId, int userId, int qty)
        {
            
                Carts cart = CartFactory.AddToCart(productId, userId, qty);
                db.Carts.Add(cart);
                db.SaveChanges();

                return cart;
            
        }

        public static Carts GetCartByProductUserId(int productId, int userId)
        {
            Carts cartExist = (from c in db.Carts where c.ProductID == productId && c.UserID == userId select c).FirstOrDefault();

            return cartExist;
        }

        public static Carts AddQuantity(Carts cart, int qty)
        {
            cart.Quantity = cart.Quantity + qty;
            db.SaveChanges();

            return cart;
        }

        public static Carts UpdateQuantity(Carts cart, int qty)
        {
            cart.Quantity = qty;
            db.SaveChanges();

            return cart;
        }

        public static List<Carts> GetCartByUserId(int userId)
        {
            List<Carts> cartList = (from c in db.Carts where c.UserID == userId select c).ToList();

            return cartList;
        }

        public static Carts DeleteCart(Carts cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();


            return cart;
        }
    }
}