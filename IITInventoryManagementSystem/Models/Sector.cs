﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual IEnumerable<Voucher> Vouchers { get; set; }

    }
}
