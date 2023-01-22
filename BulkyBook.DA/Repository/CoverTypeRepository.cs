﻿using BulkyBook.DA.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DA.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _context;
        public CoverTypeRepository(ApplicationDbContext context) : base(context)    
        {
            _context = context;
        }

        public void Update(CoverType obj)
        {
            _context.coverTypes.Update(obj);
        }
    }
}
