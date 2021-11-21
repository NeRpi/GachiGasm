using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class MangaRepository : EFRepository<Manga>, IRepository<Manga>
{
    public MangaRepository(DbContext context) : base(context) { }

    public void Delete(Manga item)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Manga> GetAll()
    {
        IQueryable<Manga> query = _table;

        return query
            .Include(item => item.Genres);
    }

    public Manga GetById(int id)
    {
        return _table.FirstOrDefault(item => item.Id == id);
    }

    public void Update(Manga item)
    {
        throw new NotImplementedException();
    }
}

