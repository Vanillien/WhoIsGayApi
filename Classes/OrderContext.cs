using Microsoft.EntityFrameworkCore;
using WhoIsGayApi.Models;

namespace WhoIsGayApi.Classes;

public class OrderContext(DbContextOptions<OrderContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Order> Orders { get; init; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);

        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=WhoIsGayDb;User Id=postgres;Password=rr7kyy00");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}