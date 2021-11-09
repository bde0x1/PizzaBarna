using System.Text.Json.Serialization;

namespace PizzaBarna.Models
{
    public class Product
    {
        public Meal MealProduct { get; set; }

        public int Amount { get; set; }

        public Product(Meal product, int amount)
        {
            this.MealProduct = product;
            this.Amount = amount;
        }

        [JsonConstructor]
        public Product()
        {
        }
    }
}