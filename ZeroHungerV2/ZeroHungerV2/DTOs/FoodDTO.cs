using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.DTOs
{
    public class FoodDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int time { get; set; }
        public int Rid { get; set; }
        public int uid { get; set; }
        public System.DateTime assigntime { get; set; }
        public string status { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}