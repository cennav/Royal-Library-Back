using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalLibrary.Domain;

namespace RoyalLibrary.Infrastructure.EntityConfigurations;

public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> entity)
    {
        entity.ToTable("Authors");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).ValueGeneratedOnAdd();
        entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
        entity.Property(x => x.Surname).IsRequired().HasMaxLength(100); 
    }
}
