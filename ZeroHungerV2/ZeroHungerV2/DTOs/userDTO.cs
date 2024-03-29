using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerV2.DTOs
{
    public class userDTO
    {
        public int id { get; set; }
        public string Uname { get; set; }
        public string pass { get; set; }
        public string Type { get; set; }
    }
}