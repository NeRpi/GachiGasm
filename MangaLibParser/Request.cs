using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace MangaLibParser;

public class Request
{
    private readonly HttpClient _client;

    public Request()
    {
        _client = new HttpClient();
    }

    public async Task<IHtmlDocument> GetHtmlDocumentAsync(string url)
    {
        using var stream = await _client.GetStreamAsync(url);

        var parser = new HtmlParser();
        var doc = await parser.ParseDocumentAsync(stream);

        return doc;
    }
}

