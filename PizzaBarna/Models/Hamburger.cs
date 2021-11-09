using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBarna.Models
{
    public class Hamburger : Meal
    {
        public Hamburger(int mealID, string name, int price, string desc)
        {
            this.MealID = mealID;
            this.Name = name;
            this.MealType = MealType.HAMBURGER;
            this.Price = price;
            this.Description = desc;
        }

        [JsonConstructor]
        public Hamburger()
        {

        }
    }
}
