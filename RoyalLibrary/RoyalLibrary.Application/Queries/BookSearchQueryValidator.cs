using FluentValidation;
using RoyalLibrary.Application.Queries.Enums;

namespace RoyalLibrary.Application.Queries;

public class BookSearchQueryValidator : AbstractValidator<BookSearchQuery>
{
    public BookSearchQueryValidator()
    {
        RuleFor(x => x.SearchType)
            .Must(x => Enum.TryParse(x, out BookSearchTypes type))
            .WithMessage("Search type is not valid");

        RuleFor(x => x.Value)
            .NotEmpty()
            .NotNull();
    }
}
