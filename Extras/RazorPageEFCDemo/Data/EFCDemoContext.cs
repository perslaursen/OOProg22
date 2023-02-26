using Microsoft.EntityFrameworkCore;
using RazorPageEFCDemo.Models;

namespace RazorPageEFCDemo.Data
{
    public class EFCDemoContext : DbContext
    {
        private IConfiguration _configuration;

        public EFCDemoContext (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("EFCDemoContext") ?? throw new InvalidOperationException("Connection string 'EFCDemoContext' not found."));
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
