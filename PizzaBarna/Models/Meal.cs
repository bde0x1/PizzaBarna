using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBarna.Models
{
    public class Meal : IMeal
    {
        public int MealID { get; set; }

        public string Name { get; set; }

        public MealType MealType { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public Amount MealAmount { get; set; }

        public Topping BonusToppings { get; set; }

        [JsonConstructor]
        public Meal()
        {

        }
    }

    public class Topping
    {
        public int Eggs { get; set; } = 0;

        public int Tomato { get; set; } = 0;

        public int Ham { get; set; } = 0;

        public int Sausage { get; set; } = 0;

        [JsonConstructor]
        public Topping()
        {
                
        }
    }
}
