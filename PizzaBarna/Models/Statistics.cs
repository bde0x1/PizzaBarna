using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBarna.Models
{
    public class Statistics
    {
        private readonly string file = "C:\\WS\\statistics.json";

        public List<StatisticsItem> PizzaStatistics { get; set; }

        public List<StatisticsItem> HamburgerStatistics { get; set; }

        public List<StatisticsItem> PastaStatistics { get; set; }

        [JsonConstructor]
        public Statistics()
        {

        }

        public Statistics GetStatistics()
        {
            
            if (File.Exists(file))
            {
                Statistics stat = null;
                try
                {
                    var fileContent = File.ReadAllText(file);
                    stat = JsonSerializer.Deserialize<Statistics>(fileContent);
                }
                catch (Exception exc)
                {
                    
                }
                
                return stat;
            }
            else
            {
                File.Create(file).Close();
                var stat = new Statistics() { PizzaStatistics = this.GetPizzaStatistics(), HamburgerStatistics = this.GetHamburgerStatistics(), PastaStatistics = this.GetPastaStatistics() };
                var text = JsonSerializer.Serialize(stat, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } });
                File.WriteAllText(file, text);
                return stat;
            }
        }

        public void SaveStatistics(Statistics stat)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
                File.Create(file).Close();
                var text = JsonSerializer.Serialize(stat, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } });
                File.WriteAllText(file, text);               
            }
        }

        private List<StatisticsItem> GetPizzaStatistics()
        {
            var menu = new Menu();
            var pizzas = new List<StatisticsItem>();
            foreach (var item in menu.Meals)
            {
                if (item.MealType == MealType.PIZZA)
                {
                    pizzas.Add(new StatisticsItem() { Product = (Pizza)item, OrderCount = 0});
                }
            }

            return pizzas;
        }

        private List<StatisticsItem> GetHamburgerStatistics()
        {
            var menu = new Menu();
            var hamburger = new List<StatisticsItem>();
            foreach (var item in menu.Meals)
            {
                if (item.MealType == MealType.HAMBURGER)
                {
                    hamburger.Add(new StatisticsItem() { Product = (Hamburger)item, OrderCount = 0});
                }
            }

            return hamburger;
        }

        private List<StatisticsItem> GetPastaStatistics()
        {
            var menu = new Menu();
            var pasta = new List<StatisticsItem>();
            foreach (var item in menu.Meals)
            {
                if (item.MealType == MealType.PASTA)
                {
                    pasta.Add(new StatisticsItem() { Product = (Pasta)item, OrderCount = 0});
                }
            }

            return pasta;
        }
    }

    public class StatisticsItem
    {
        public Meal Product { get; set; }

        public int OrderCount { get; set; }

        [JsonConstructor]
        public StatisticsItem()
        {

        }
    }
}
