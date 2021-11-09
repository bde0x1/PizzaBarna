using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBarna.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MealType
    {
        [EnumMember(Value = "PIZZA")]
        PIZZA = 0,
        [EnumMember(Value = "HAMBURGER")]
        HAMBURGER = 1,
        [EnumMember(Value = "PASTA")]
        PASTA = 2
    }

    public interface IMeal
    {
        public int MealID { get; set; }

        public string Name { get; set; }

        public MealType MealType { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }
    }
}
