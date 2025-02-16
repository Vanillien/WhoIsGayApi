using Microsoft.EntityFrameworkCore;
using WhoIsGayApi.Models;

namespace WhoIsGayApi.Classes;

public class MessagesContext(DbContextOptions<MessagesContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Message> Messages { get; init; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);

        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=WhoIsGayMessagesDb;User Id=postgres;Password=rr7kyy00");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
    }
}