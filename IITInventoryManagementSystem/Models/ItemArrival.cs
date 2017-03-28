using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.Models
{
    public class ItemArrival
    {
        public int Id { get; set; }
        public DateTime Date {get; set; }

        public virtual Voucher Voucher { get; set; }

        public virtual IEnumerable<Item> Items { get; set; }
    }
}