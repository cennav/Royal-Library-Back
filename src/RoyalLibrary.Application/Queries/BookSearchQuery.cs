using MediatR;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Application.Common.Infrastructure;
using RoyalLibrary.Application.Queries.Dtos;
using RoyalLibrary.Application.Queries.Enums;
using RoyalLibrary.Domain;

namespace RoyalLibrary.Application.Queries;

public class BookSearchQuery : IRequest<IEnumerable<BookSearchQueryResponseDto>>
{
    public string SearchType { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class BookSearchQueryHandler : IRequestHandler<BookSearchQuery, IEnumerable<BookSearchQueryResponseDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDictionary<BookSearchTypes, Action<IQueryable<Book>, string>> filters = 
        new Dictionary<BookSearchTypes, Action<IQueryable<Book>, string>>
        {
            { BookSearchTypes.Author, AddAuthorFilter },
            { BookSearchTypes.ISBN, AddISBNFilter },
            { BookSearchTypes.Title, AddTitleFilter },
            { BookSearchTypes.Category, AddCategoryFilter },

        };

    public BookSearchQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookSearchQueryResponseDto>> Handle(BookSearchQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Books.AsQueryable();
        var searchType = Enum.Parse<BookSearchTypes>(request.SearchType.Trim());
        request.Value = request.Value.Trim();

        filters[searchType].Invoke(query, request.Value);

        var result = await query.Select(x => new BookSearchQueryResponseDto()
        {
            Title = x.Title,
            Publisher = x.Publisher.Name,
            Authors = string.Join(",", x.Authors.Select(x => x.FullName)),
            Type = x.Type.ToString(),
            ISBN = x.ISBN,
            Category = string.Join(",", x.Categories.Select(x => x.Name)),
            AvailableCopies = $"{x.UsedCopies}/{x.TotalCopies}"
        }).ToListAsync(cancellationToken);

        return result;
    }

    private static IEnumerable<string> GetValuesSplitted(string value)
        => value.Split(",", StringSplitOptions.TrimEntries)
            .SelectMany(x => x.Split(" "))
            .Select(x => x.ToUpper())
            ?? Enumerable.Empty<string>();
    

    private static void AddAuthorFilter(IQueryable<Book> query, string value)
    {
        var values = GetValuesSplitted(value);
        query.Where(x =>
            x.Authors.Any(x => values.Contains(x.Name.ToUpper()) || values.Contains(x.Surname.ToUpper())));
    }

    private static void AddISBNFilter(IQueryable<Book> query, string value)
        => query.Where(x => x.ISBN.Contains(value));

    private static void AddTitleFilter(IQueryable<Book> query, string value)
        => query.Where(x => x.Title.ToUpper().Contains(value.ToUpper()));

    private static void AddCategoryFilter(IQueryable<Book> query, string value)
    {
        var values = GetValuesSplitted(value);
        query.Where(x => x.Categories.Any(x => x.Synonyms.Any(y => values.Contains(y.ToUpper()))));
    }
}
