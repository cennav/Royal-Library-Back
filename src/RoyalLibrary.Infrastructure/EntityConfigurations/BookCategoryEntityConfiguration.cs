using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalLibrary.Infrastructure.EntityConfigurations;
public class BookCategoryEntityConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> entity)
    {
        entity.ToTable("BookCategories");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).ValueGeneratedOnAdd();
        entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
        entity.Property(x => x.Synonyms).IsRequired().HasMaxLength(300)
            .HasConversion(
            x => string.Join(",", x),
            y => (IEnumerable<string>)y.Split(",", StringSplitOptions.RemoveEmptyEntries));
    }
}
