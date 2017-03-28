using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime AddingTime { get; set; }

        public virtual Item Item { get; set; }
    }
}