using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public string Location { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemArrival Arrival { get; set; }

        public virtual IEnumerable<RequisedItem> RequisedItems { get; set; }
    }
}