﻿using BulkyBook.DA.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DA.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void Save()
        {
           _context.SaveChanges();  
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
