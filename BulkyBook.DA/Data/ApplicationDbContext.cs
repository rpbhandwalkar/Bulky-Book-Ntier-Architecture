using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> coverTypes { get; set; }
        public DbSet<Product> products  { get; set; }
    }
}
