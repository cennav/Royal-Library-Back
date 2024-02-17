using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Domain;

namespace RoyalLibrary.Application.Common.Infrastructure;

public interface IApplicationDbContext
{
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Books { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}