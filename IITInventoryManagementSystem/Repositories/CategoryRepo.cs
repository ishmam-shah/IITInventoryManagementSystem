using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;
using IITInventoryManagementSystem.Models;
using IITInventoryManagementSystem.ViewModel;

namespace IITInventoryManagementSystem.Repositories
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<GetCategory> GetCategory();
    }
    public class CategoryRepo:ICategoryRepo
    {
        private ApplicationDbContext _context=null;

        public CategoryRepo(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        
        public IEnumerable<GetCategory> GetCategory()
        {
            try
            {
                List<GetCategory> categories = new List<GetCategory>
                {
                    new GetCategory {CategoryName = "Pen",AvailableAmount = 10},
                    new GetCategory{CategoryName = "Computer",AvailableAmount = 11},
                    new GetCategory{CategoryName = "Paper",AvailableAmount = 15},
                    new GetCategory{CategoryName = "Book",AvailableAmount = 13},
                };
                return categories;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                return _context.Categories.Where(s => s.IsDeleted == true).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}