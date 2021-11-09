using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBarna.Models
{
    public class Order
    {
        public List<Product> Products { get; set; }

        public CouponCode ValidCoupon { get; set; }

        [JsonConstructor]
        public Order()
        {
             
        }
    }
}
