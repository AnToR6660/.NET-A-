using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerV2.DTOs
{
    public class LoginDTO
    {
        
        public string Uname { get; set; }

        
        public string pass { get; set; }
    }
}