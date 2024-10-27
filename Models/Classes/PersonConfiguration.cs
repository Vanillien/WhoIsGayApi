using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WhoIsGayApi.Models.Classes;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(p => p.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100);
        
        builder.Property(p => p.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100);

        builder.Property(p => p.Gay)
            .HasColumnName("Gay");

        builder.Property(p => p.Email)
            .HasColumnName("Email")
            .HasMaxLength(100);

        builder.Property(p => p.Orderer)
            .HasColumnName("Orderer");

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(500);
    }
}