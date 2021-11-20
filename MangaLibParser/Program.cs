using BLL.Services;

namespace MangaLibParser;

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

        var parser = new Parser();
        var mainTask = parser.PopulateMangasTable();
        Task.WaitAll(mainTask);
    }
}