namespace MangaLibParser;

public class Program
{
    public static void Main()
    {
        var parser = new Parser();
        var mainTask = parser.PopulateMangasTable();
        Task.WaitAll(mainTask);
    }
}