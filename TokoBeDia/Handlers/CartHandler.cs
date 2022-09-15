using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;
using TokoBeDia.ViewModel;

namespace TokoBeDia.Handlers
{
    public class CartHandler
    {

        public static Carts AddToCart(Products product, int userId, int qty)
        {
            Carts cart = CartRepo.GetCartByProductUserId(product.ID, userId);
            if(cart != null)
            {
                ProductRepo.updateStock(product, qty * -1);
                CartRepo.AddQuantity(cart, qty);
                return cart;
            }else
            {
                ProductRepo.updateStock(product, qty * -1);
                return CartRepo.InsertCart(product.ID, userId, qty);
            }   
        }

        public static List<ProductCartViewModel> GetCartByUserId(int userId)
        {
            List<Carts> cartList = CartRepo.GetCartByUserId(userId);
            List<ProductCartViewModel> vm = new List<ProductCartViewModel>();

            foreach (Carts cart in cartList ?? Enumerable.Empty<Carts>())
            {
                Products product = ProductRepo.getProductById(cart.ProductID);
                vm.Add(new ProductCartViewModel()
                {
                    productId = cart.ProductID,
                    name = product.Name,
                    price = product.Price,
                    quantity = cart.Quantity,
                    subtotal = product.Price * cart.Quantity


                });


            }
            return vm;
        }

        public static Carts DeleteCartById(int productId, int userId)
        {
            Debug.WriteLine("Handler: " + userId);
            Carts cart = CartRepo.GetCartByProductUserId(productId, userId);
            Products product = ProductRepo.getProductById(productId);
            if(cart != null) { 
                ProductRepo.updateStock(product, cart.Quantity);
            }else
            {
                return null;
            }
            return CartRepo.DeleteCart(cart);
        }

        public static Carts GetCartByProductUserId(int productId, int userId)
        {
            return CartRepo.GetCartByProductUserId(productId, userId);
        }

        public static Carts UpdateQuantity(Products product, int userId, int qty)
        {
            Carts cart = CartRepo.GetCartByProductUserId(product.ID, userId);
            ProductRepo.updateStock(product, cart.Quantity - qty);

            return CartRepo.UpdateQuantity(cart, qty);
            
        }

        public static void CheckOut(int userId, int paymentTypeId)
        {
            HeaderTransactions ht = HeaderTransactionRepo.AddTransaction(userId, paymentTypeId);
            List<Carts> cartList = CartRepo.GetCartByUserId(userId);
            foreach(Carts c in cartList)
            {
                DetailTransactionRepo.AddDetail(ht.ID, c.ProductID, c.Quantity);
                CartRepo.DeleteCart(c);
            }

        }
    }
}