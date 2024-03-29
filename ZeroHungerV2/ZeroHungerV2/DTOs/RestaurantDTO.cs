using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.DTOs
{
    public class RestaurantDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public virtual user user { get; set; }
    }
}