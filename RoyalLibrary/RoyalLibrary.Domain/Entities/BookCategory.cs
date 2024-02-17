namespace RoyalLibrary.Domain;
public class BookCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<string> Synonyms { get; set; } = new List<string>();
}

