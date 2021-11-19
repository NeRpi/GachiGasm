using DAL.Contexts.SQLServer;
using DAL.Repositories;
using DAL.Entities;

namespace BLL.Services;

public class MangaManager
{
    public IRepository<Manga> _repository;

    public MangaManager()
    {
        _repository = new EFRepository<Manga>(new SQLServerContext());
    }

    public void AddNewManga(Manga manga)
    {
        _repository.Create(manga);
        _repository.SaveChanges();
    }

    public IEnumerable<Manga> GetAll()
    {
        return _repository.GetAll();
    }
}

