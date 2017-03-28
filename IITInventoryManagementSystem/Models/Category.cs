using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual IEnumerable<ItemCategory> ItemCategories { get; set; }
    }
}