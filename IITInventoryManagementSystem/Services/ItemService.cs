using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using IITInventoryManagementSystem.DAL;
using IITInventoryManagementSystem.Repositories;
using IITInventoryManagementSystem.ViewModel;

namespace IITInventoryManagementSystem.Services
{
    public interface IItemService
    {
        ResponseDto<GetCategoryResDto> GetCategory();
    }
    public class ItemService:IItemService
    {
        public UnitOfWork unitOfWork=null;

        public ItemService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ResponseDto<GetCategoryResDto> GetCategory()
        {
            var responseToReturn = new ResponseDto<GetCategoryResDto>();
            var getCategoryRes = new GetCategoryResDto();

            try
            {
                getCategoryRes.Categories= unitOfWork.CategoryRepo.GetCategory().ToArray();
                responseToReturn.Body = getCategoryRes;
                responseToReturn.Message = "ok";
                responseToReturn.Code = "200";
                return responseToReturn;
            }
            catch (Exception e)
            {
                responseToReturn.Message = "error";
                responseToReturn.Code = "404";
                return responseToReturn;
            }
        }
    }
}
