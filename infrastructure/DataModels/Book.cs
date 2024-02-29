namespace infrastructure.DataModels;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public int Rating { get; set; }
    public int SpiceLevel { get; set; }
    public string Description { get; set; }
    public DateTime AddedAt { get; set; }
    public string CoverUrl { get; set; }
}