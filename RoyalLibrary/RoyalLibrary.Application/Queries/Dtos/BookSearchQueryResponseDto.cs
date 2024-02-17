namespace RoyalLibrary.Application.Queries.Dtos;

public class BookSearchQueryResponseDto
{
    public int Id { get; set; } 
    public string Title { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string Authors { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;    
    public string ISBN { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;   
    public string AvailableCopies { get; set; } = string.Empty;
}
