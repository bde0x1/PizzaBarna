using Microsoft.AspNetCore.Mvc;
using PizzaBarna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBarna.Controllers
{
    public class CartController : Controller
    {
        private readonly Coupon coupons = new Coupon();

        public IActionResult Index()
        {
            var orders = this.HttpContext.Session.GetComplexData<List<Product>>("Orders");
            return View(orders);
        }

        [HttpPost]
        public IActionResult Index(string coupon)
        {
            bool validCoupon = false;
            CouponCode couponCode = null;
            foreach (var realCoupon in coupons.Coupons)
            {
                if (realCoupon.Code == coupon)
                {
                    validCoupon = true;
                    couponCode = realCoupon;
                    break;
                }
            }

            var orders = this.HttpContext.Session.GetComplexData<List<Product>>("Orders");
            Order order = null;
            if (validCoupon)
            {
                order = new Order() { Products = orders, ValidCoupon = couponCode};
                this.HttpContext.Session.SetComplexData("ValidOrder", order);
            }
            else
            {
                this.ViewData["WrongCouponCode"] = coupon;
            }
            this.ViewData["Order"] = order;
            
            return View(orders);
        }

        public IActionResult Remove(int id)
        {
            var orders = this.HttpContext.Session.GetComplexData<List<Product>>("Orders");
            foreach (var item in orders)
            {
                if (id == item.MealProduct.MealID)
                {
                    orders.Remove(item);
                    break;
                }
            }

            this.HttpContext.Session.SetComplexData("Orders", orders);
            return View();
        }

        public IActionResult Buy()
        {
            var orders = this.HttpContext.Session.GetComplexData<List<Product>>("Orders");

            Order order = this.HttpContext.Session.GetComplexData<Order>("ValidOrder");
            if (order != null)
            {
                order.Products = orders;

                this.SetStatistics(order);
            }
            else
            {
                order = new Order();
                order.Products = orders;
                this.SetStatistics(order);
            }
            


            orders.Clear();
            order = null;

            this.HttpContext.Session.SetComplexData("Orders", orders);            
            this.HttpContext.Session.SetComplexData("ValidOrder", order);            
            return View();
        }

        private void SetStatistics(Order order)
        {
            var stat = new Statistics();
            var stats = stat.GetStatistics();

            SetHelper(stats.PizzaStatistics, order.Products);
            SetHelper(stats.PastaStatistics, order.Products);
            SetHelper(stats.HamburgerStatistics, order.Products);

            stat.SaveStatistics(stats);
        }

        private void SetHelper(List<StatisticsItem> items, List<Product> products)
        {
            foreach (var statItem in items)
            {
                foreach (var product in products)
                {
                    if (statItem.Product.MealID == product.MealProduct.MealID)
                    {
                        statItem.OrderCount += product.Amount;
                        break;
                    }
                }
            }
        }
    }
}
