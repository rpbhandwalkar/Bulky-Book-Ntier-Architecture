using BulkyBook.DA.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DA.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)    
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.products.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {

            }
        }
    }
}
