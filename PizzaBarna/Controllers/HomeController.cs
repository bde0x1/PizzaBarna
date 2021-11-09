using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBarna.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBarna.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Menu menu = new Menu();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View(menu.Meals);
        }

        public IActionResult AddToCart(string data, string topping = null)
        {
            Meal newItem = null;
            if (data.Contains(MealType.PIZZA.ToString()))
            {
                newItem = JsonSerializer.Deserialize<Pizza>(data);
                if (topping != null)
                {
                    if (topping.Contains("Eggs"))
                    {
                        (newItem as Pizza).BonusToppings.Eggs++;
                    }
                    else if (topping.Contains("Tomato"))
                    {
                        (newItem as Pizza).BonusToppings.Tomato++;
                    }
                    else if (topping.Contains("Ham"))
                    {
                        (newItem as Pizza).BonusToppings.Ham++;
                    }
                    else if (topping.Contains("Sausage"))
                    {
                        (newItem as Pizza).BonusToppings.Sausage++;
                    }
                }               
            }
            else
            {
                newItem = JsonSerializer.Deserialize<Meal>(data);
            }

            return View(newItem);
        }

        public IActionResult FinalizeAddToCart(string data)
        {
            if (data.Contains(MealType.PIZZA.ToString()))
            {
                ExecuteAddToCart<Pizza>(data);
            }
            else if (data.Contains(MealType.HAMBURGER.ToString()))
            {
                ExecuteAddToCart<Hamburger>(data);
            }
            else if (data.Contains(MealType.PASTA.ToString()))
            {
                ExecuteAddToCart<Pasta>(data);
            }
            return View();
        }

        private void ExecuteAddToCart<T>(string data) where T : Meal
        {
            var result = JsonSerializer.Deserialize<T>(data);
            var orders = this.HttpContext.Session.GetComplexData<List<Product>>("Orders");
            if (orders != null)
            {
                orders.Add(new Product(result, 1));
                this.HttpContext.Session.SetComplexData("Orders", orders);
            }
            else
            {
                orders = new List<Product>();
                orders.Add(new Product(result, 1));
                this.HttpContext.Session.SetComplexData("Orders", orders);
            }                     
        }

        public IActionResult Statistics()
        {
            Statistics stat = new Statistics();
            var stats = stat.GetStatistics();
            stat.PizzaStatistics = stats.PizzaStatistics.OrderByDescending(m => m.OrderCount).ToList();
            stat.HamburgerStatistics = stats.HamburgerStatistics.OrderByDescending(m => m.OrderCount).ToList();
            stat.PastaStatistics = stats.PastaStatistics.OrderByDescending(m => m.OrderCount).ToList();
            return View(stat);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        
    }
}
