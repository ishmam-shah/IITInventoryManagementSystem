using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.ViewModel
{
    public class GetCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int AvailableAmount { get; set; }
    }

    public class GetCategoryResDto
    {
        public GetCategory[] Categories { get; set; }
    }
}