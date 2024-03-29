using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.DTOs
{
    public class ApprovedDTO
    {
        public int id { get; set; }
        public int Fid { get; set; }
        public int Eid { get; set; }
        public int Rid { get; set; }
        public Nullable<System.DateTime> deliveredtime { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Food Food { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}