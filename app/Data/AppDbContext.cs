using Microsoft.EntityFrameworkCore;
using Baloon_AB.Models;

namespace Baloon_AB.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project>  Projects { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<Order>    Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<OrderRow>(eb => {
                    eb.HasNoKey();
                    eb.ToView("order_rows");
            });
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
