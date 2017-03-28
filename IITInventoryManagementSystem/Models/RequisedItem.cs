using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.Models
{
    public class RequisedItem
    {
        public int Id { get; set; }
        public virtual Item Item { get; set; }
        public virtual RequisitionSlip RequisitionSlip { get; set; }
    }
}