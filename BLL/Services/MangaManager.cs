using DAL.Contexts.SQLServer;
using DAL.Repositories;
using DAL.Entities;

namespace BLL.Services;

public class MangaManager
{
    public IRepository<Manga> _repository;

    public MangaManager()
    {
        _repository = new MangaRepository(new SQLServerContext());
    }

    public void AddNewManga(Manga manga)
    {
        _repository.Create(manga);
        _repository.SaveChanges();
    }

    public void DelManga(Manga manga)
    {
        _repository.Delete(manga);
        _repository.SaveChanges();
    }

    public void AddNewMangas(IEnumerable<Manga> mangas)
    {
        _repository.CreateRange(mangas);
        _repository.SaveChanges();

        Console.WriteLine($"{mangas.Count()} rows saved.");
    }

    public void Update(Manga manga)
    {
        _repository.Update(manga);
        _repository.SaveChanges();
    }

    public IQueryable<Manga> GetAll()
    {
        return _repository.GetAll();
    }
}

