using APIHomework.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIHomework.DAL.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }

        

    }
}
