using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBarna.Models
{
    public class Coupon
    {
        public List<CouponCode> Coupons { get; set; }

        public Coupon()
        {
            this.Coupons = new List<CouponCode>() { 
                new CouponCode() { Code = "CodeA", Discount = 20 },
                new CouponCode() { Code = "CodeB", Discount = 30 },
                new CouponCode() { Code = "CodeC", Discount = 40 },
                new CouponCode() { Code = "CodeD", Discount = 50 }
            };
        }
    }


    public class CouponCode
    {
        public string Code { get; set; }

        public int Discount { get; set; }

        [JsonConstructor]
        public CouponCode()
        {

        }
    }
}
