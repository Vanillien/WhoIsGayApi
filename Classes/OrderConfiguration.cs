using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhoIsGayApi.Models;

namespace WhoIsGayApi.Classes;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(p => p.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100);
        
        builder.Property(p => p.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100);

        builder.Property(p => p.Gay)
            .HasColumnName("gay");
        
        builder.Property(p => p.Orderer)
            .HasColumnName("orderer")
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(p => p.CreationTime)
            .HasColumnName("creation_time");
    }
}