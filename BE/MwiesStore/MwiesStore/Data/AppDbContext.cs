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
        public DbSet<Bills> Bills { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<PromotionDetail> PromotionDetails { get; set; }
        public DbSet<ProductWish> ProductWishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bills>(e =>
            {
                e.ToTable("Bills");
                e.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<Users>(e =>
            {
                e.ToTable("Users");
                e.Property(e => e.Birthdate).HasColumnType("date");
            });

            modelBuilder.Entity<Products>(e =>
            {
                e.ToTable("Products");
                e.Property(e => e.StartDate).HasColumnType("date");
                e.Property(e => e.EndDate).HasColumnType("date");
            });

            modelBuilder.Entity<Promotions>(e =>
            {
                e.ToTable("Promotions");
                e.Property(e => e.StartDate).HasColumnType("date");
                e.Property(e => e.EndDate).HasColumnType("date");
            });

        }
    }
}
