using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBarna.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Amount
    {
        [EnumMember(Value = "SIZE50CM")]
        SIZE50CM = 0,
        [EnumMember(Value = "SIZE30CM")]
        SIZE30CM = 1
    }

    public class Pizza : Meal
    {
        public Pizza(int mealID, string name, Amount mealAmount, int price, string desc, Topping topping)
        {
            this.MealID = mealID;
            this.Name = name;
            this.MealAmount = mealAmount;
            this.MealType = MealType.PIZZA;
            this.Price = price;
            this.Description = desc;
            this.BonusToppings = topping;
        }

        [JsonConstructor]
        public Pizza()
        {

        }
    }
}
