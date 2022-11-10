using Microsoft.EntityFrameworkCore;
using MwiesStore.Models;

namespace MwiesStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Images> Images { get; set; }

    }
}
