using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class MangaRepository : EFRepository<Manga>, IRepository<Manga>
{
    public MangaRepository(DbContext context) : base(context) { }


    public override IQueryable<Manga> GetAll()
    {
        IQueryable<Manga> query = _table;

        return query
            .Include(item => item.Genres);
    }

    public Manga GetById(int id)
    {
        return _table.FirstOrDefault(item => item.Id == id);
    }
}

