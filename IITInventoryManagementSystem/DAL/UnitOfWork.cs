using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;
using IITInventoryManagementSystem.Repositories;
using IITInventoryManagementSystem.Services;

namespace IITInventoryManagementSystem.DAL
{
    public class UnitOfWork:IDisposable
    {
        private ApplicationDbContext context=null;
        public UnitOfWork()
        {
            context = new ApplicationDbContext();
        }

        private ICategoryRepo categoryRepo=null;

        public ICategoryRepo CategoryRepo
        {
            get
            {
                if (categoryRepo == null)
                {
                    categoryRepo = new CategoryRepo(context);
                }
                return categoryRepo;
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}