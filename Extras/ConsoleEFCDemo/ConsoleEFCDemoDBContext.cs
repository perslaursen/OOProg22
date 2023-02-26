
using Microsoft.EntityFrameworkCore;

public class ConsoleEFCDemoDBContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCDemo");
    }
}

