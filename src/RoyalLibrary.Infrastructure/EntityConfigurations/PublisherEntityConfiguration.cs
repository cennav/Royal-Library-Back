using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Domain;

namespace RoyalLibrary.Infrastructure.EntityConfigurations;

public class PublisherEntityConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> entity)
    {
        entity.ToTable("Publishers");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).ValueGeneratedOnAdd();
        entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
    }
}
