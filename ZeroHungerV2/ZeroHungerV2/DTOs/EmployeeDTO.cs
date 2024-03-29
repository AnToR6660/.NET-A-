using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.DTOs
{
    public class EmployeeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string contact { get; set; }
        public string status { get; set; }
        public virtual user user { get; set; }
    }
}