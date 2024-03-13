using LabTask5.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTask5.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}