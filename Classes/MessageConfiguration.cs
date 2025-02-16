using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhoIsGayApi.Models;

namespace WhoIsGayApi.Classes;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages");

        builder.Property(p => p.Text)
            .HasColumnName("text")
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(p => p.User)
            .HasColumnName("user")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.CreationTime)
            .HasColumnName("time");
    }
}