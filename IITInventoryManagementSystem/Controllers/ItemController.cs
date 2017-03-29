using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IITInventoryManagementSystem.DAL;
using IITInventoryManagementSystem.Services;

namespace IITInventoryManagementSystem.Controllers
{
    public class ItemController : Controller
    {
        //private IItemService _itemService=new ItemService();
        private UnitOfWork _unitOfWork = null;
        private IItemService _itemService=null;

        public ItemController()
        {
            _unitOfWork = new UnitOfWork();
            _itemService =new ItemService(_unitOfWork);
        }
        public ItemController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public ItemController(IItemService itemService)
        {
            this._itemService = itemService;
        }

        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategories()
        {
            return this.Json(_itemService.GetCategory(), JsonRequestBehavior.AllowGet);
        }
    }
}