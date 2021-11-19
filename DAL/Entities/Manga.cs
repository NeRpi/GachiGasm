using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class Manga
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageSrc { get; set; }
    // public ICollection<string> Genres { get; set; }
    public string? Type { get; set; }
    public int? ChaptersCount { get; set; }
    public int? ReleaseYear { get; set; }
    public string? ItemStatus { get; set; }
    public string? TranslationStatus { get; set; }
    public string? Author { get; set; }
    public string? Painter { get; set; }
    public string? Description { get; set; }
}

