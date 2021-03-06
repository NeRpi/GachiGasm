using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class Manga
{
    public Manga()
    {
        Genres = new List<Genre>();
    }

    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageSrc { get; set; }
    public string? Type { get; set; }
    public int? ReleaseYear { get; set; }
    public string? Description { get; set; }
    public float? Rating { get; set; }
    public List<Genre> Genres { get; set; }
}

