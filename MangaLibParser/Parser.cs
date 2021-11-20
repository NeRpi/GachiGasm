using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

using DAL.Entities;
using BLL.Services;

namespace MangaLibParser;

public class Parser
{
    private readonly Request _request;
    private readonly MangaManager _manager;

    public Parser()
    {
        _request = new Request();
        _manager = new MangaManager();
    }

    public IHtmlDocument BasePage => _request.GetHtmlDocumentAsync(Options.baseUrl).Result;

    public int GetPageCount()
    {
        var pageLinks = BasePage.QuerySelectorAll("a.step");

        foreach (var pageLink in pageLinks.Reverse())
        { 
            if(int.TryParse(pageLink.TextContent, out var lastPage))
            {
                return lastPage;
            }
        }

        return 0;
    }

    public async Task PopulateMangasTable()
    {
        var pageCount = GetPageCount();
        var pageLink = @"https://readmanga.io/list?sortType=POPULARITY&offset=";
        var pageSize = 70;
        var mangas = new List<Manga>();
        for (int page = 0; page < pageCount; page++)
        {
            var nextPage = pageLink + (pageSize * page).ToString();
            Console.WriteLine($"Next page: {nextPage}");
            mangas = mangas.Concat((await GetPageMangas(nextPage))).ToList();

            if (page % 10 == 0)
            {
                _manager.AddNewMangas(mangas);
                mangas.Clear();
            }
        }

        _manager.AddNewMangas(mangas);
    }

    public async Task<IEnumerable<Manga>> GetPageMangas(string pageUrl)
    {
        var mangas = new List<Manga>();
        var pageDoc = await _request.GetHtmlDocumentAsync(pageUrl);
        var mangaLinks = pageDoc.QuerySelectorAll("div.desc > h3 > a");
       
        foreach (var manga in mangaLinks)
        {
            mangas.Add(await ParseMangaPage(Options.mangaPageBase + manga.GetAttribute("href")));
        }

        return mangas;
    }

    public async Task<Manga> ParseMangaPage(string url)
    {
        var manga = new Manga();
        var page = await _request.GetHtmlDocumentAsync(url);

        manga.Name = page.QuerySelector("span.name")?.TextContent;
        manga.Description = page.QuerySelector("div.manga-description")?.TextContent ?? page.QuerySelector("div.manga-description > p")?.TextContent;
        manga.ReleaseYear = int.Parse(page.QuerySelector("span.elem_year > a")?.TextContent ?? "-1");
        manga.Type = page.QuerySelector("span.elem_category > a")?.TextContent;
        manga.Rating = float.Parse(page.QuerySelector("span.rating-block")?.GetAttribute("data-score")?.Replace('.', ',') ?? "0");
        manga.ImageSrc = page.QuerySelector("div.picture-fotorama > img")?.GetAttribute("src");
        manga.Genres = page.All
            .Where(m => m.LocalName == "span" && m.GetAttribute("class") == "elem_genre ")
            .Select(i => new Genre(i.TextContent.Trim(new char[] { ' ', ',' })))
            .ToList();

        return manga;

    }
}

