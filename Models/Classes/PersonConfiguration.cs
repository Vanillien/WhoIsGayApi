using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WhoIsGayApi.Models.Classes;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

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
            .HasColumnName("orderer");

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(p => p.CreationTime)
            .HasColumnName("creation_time");
    }
}