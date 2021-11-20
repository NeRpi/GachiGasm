using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class Genre
{
    public Genre() { }

    public Genre(string name)
    {
        Name = name;
    }

    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}

