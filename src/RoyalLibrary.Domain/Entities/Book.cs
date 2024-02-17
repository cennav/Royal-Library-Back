using RoyalLibrary.Domain.Enums;

namespace RoyalLibrary.Domain;
public class Book
{
    public int Id { get; set; }
    public string ISBN { get; set; } = string.Empty;    
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = new Publisher();
    public BookTypes Type { get; set; }
    public int TotalCopies { get; set; }
    public int UsedCopies { get; set; }
    public ICollection<Author> Authors { get; set; } = new List<Author>();
    public ICollection<BookCategory> Categories { get; set; } = new List<BookCategory>();
}