using Microsoft.EntityFrameworkCore;

namespace WhoIsGayApi.Classes;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.LogTo(Console.WriteLine);

        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=WhoIsGayDb;User Id=postgres;Password=rr7kyy00");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    }

    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }
    
}