using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace PizzaBarna.Models
{
    public class Menu
    {
        public List<IMeal> Meals { get; set; }

        public Menu()
        {
            this.Meals = new List<IMeal>()
            {
                new Pizza(1001, "Hawaii", Amount.SIZE30CM, 1650, "desc", new Topping()),
                new Pizza(1002, "Hawaii", Amount.SIZE50CM, 2650, "desc", new Topping()),
                new Pizza(1003, "Pepperoni", Amount.SIZE30CM, 1600, "desc", new Topping()),
                new Pizza(1004, "Pepperoni", Amount.SIZE50CM, 2600, "desc", new Topping()),
                new Pizza(1005, "Bolognai", Amount.SIZE30CM, 1670, "desc", new Topping()),
                new Pizza(1006, "Bolognai", Amount.SIZE50CM, 2670, "desc", new Topping()),
                new Pizza(1007, "Carbonara", Amount.SIZE30CM, 1680, "desc", new Topping()),
                new Pizza(1008, "Carbonara", Amount.SIZE50CM, 2680, "desc", new Topping()),
                new Pizza(1009, "Margarita", Amount.SIZE30CM, 1500, "desc", new Topping()),
                new Pizza(1010, "Margarita", Amount.SIZE50CM, 2500, "desc", new Topping()),

                new Hamburger(1011, "Chees Burger", 1850, "desc"),
                new Hamburger(1012, "Blue-Chees Burger", 1850, "desc"),
                new Hamburger(1013, "Dubla Burger", 1850, "desc"),
                new Hamburger(1014, "Yala Burger", 1850, "desc"),
                new Hamburger(1015, "Black Burger", 1850, "desc"),

                new Pasta(1016, "Bolognai spagetti", 1650, "desc"),
                new Pasta(1017, "Carbonara", 1650, "desc"),
                new Pasta(1018, "Macaroni", 1650, "desc"),
                new Pasta(1019, "Garnela", 1650, "desc"),
                new Pasta(1020, "Marha", 1650, "desc")
            };
        }
    }
}
