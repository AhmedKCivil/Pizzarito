using Core.Entities;
using Core.Entities.Order_Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace PizzaritoShop.Data

{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<AllOrders> OrdersTable { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship
            modelBuilder.Entity<AllOrders>()
                .HasMany(o => o.CartItems)                  // Indicates that AllOrders has many CartItems
                .WithOne(c => c.Order)                      // Indicates that each CartItem is associated with one AllOrders
                .HasForeignKey(c => c.AllOrdersId);         // Specifies that CartItem's foreign key is AllOrders

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
