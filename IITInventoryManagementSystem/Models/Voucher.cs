using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }

        public virtual Sector Sector{get; set; }
        public virtual IEnumerable<ItemArrival> ItemsArrival { get; set; }

    }
}