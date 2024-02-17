using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Domain;
using RoyalLibrary.Domain.Enums;

namespace RoyalLibrary.Infrastructure.EntityConfigurations;
public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> entity)
    {
        entity.ToTable("Books");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).ValueGeneratedOnAdd();
        entity.Property(x => x.ISBN).IsRequired().HasColumnType("text");
        entity.Property(x => x.Title).IsRequired().HasMaxLength(100);
        entity.Property(x => x.Type).IsRequired().HasMaxLength(10)
            .HasConversion(
                x => x.ToString(),
                y => Enum.Parse<BookTypes>(y));

        
        entity.HasMany(x => x.Authors).WithMany();
        entity.HasMany(x => x.Categories).WithMany();
        entity.HasOne(x => x.Publisher).WithMany()
           .HasForeignKey(x => x.PublisherId);
    }
}
