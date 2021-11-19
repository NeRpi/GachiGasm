using BLL.Services;
using DAL.Entities;

public class Program
{
    public static void Main()
    {
        var manager = new MangaManager();

        /* var testManga = new Manga()
        {
            Name = "Test",
            Description = "Test manga"
        };

        manager.AddNewManga(testManga); */

        foreach (var manga in manager.GetAll())
        {
            Console.WriteLine(manga.Name);
            Console.WriteLine(manga.Description);
        }
    }
}