using System.ComponentModel.DataAnnotations;

namespace sarah_library.TransferModels;

public class UpdateBookRequestDto
{
    public int BookId { get; set; }
    [MinLength(5)]
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author  { get; set; }
    public string Publisher { get; set; }
    public int Rating { get; set; }
    public int SpiceLevel { get; set; }
    public string Description { get; set; }
    
}