using Microsoft.EntityFrameworkCore;
using EnvarterTakip.Models;

namespace EnvarterTakip.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) //base anahtar kelime 
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products{get;set;}
    }
}
