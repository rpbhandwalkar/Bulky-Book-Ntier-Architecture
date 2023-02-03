using BulkyBook.DA.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DA.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository category { get; private set; }
        public ICoverTypeRepository coverType { get; private set; }

        public IProductRepository product { get; private set; }

        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;
            category = new CategoryRepository(_context);
            coverType = new CoverTypeRepository(_context);
            product = new ProductRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
       
    }
}
