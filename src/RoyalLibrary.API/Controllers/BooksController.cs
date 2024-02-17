using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.Application.Queries;
using RoyalLibrary.Application.Queries.Dtos;

namespace RoyalLibrary.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet("[action]")]
    public async Task<IEnumerable<BookSearchQueryResponseDto>> Search([FromQuery] BookSearchQuery query, CancellationToken cancellationToken)
        => await _mediator.Send(query, cancellationToken);
}
