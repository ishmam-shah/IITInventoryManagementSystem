using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.ViewModel
{
    public class ResponseDto<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public T Body { get; set; }
    }
}