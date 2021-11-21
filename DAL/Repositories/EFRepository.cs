using DAL.Contexts.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class EFRepository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _table;

    public EFRepository(DbContext context)
    {
        _context = context;
        _table = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _table.ToList();
    }

    public void Create(T item) => _table.Add(item);
    public void CreateRange(IEnumerable<T> items) => _table.AddRange(items);
    public void SaveChanges() => _context.SaveChanges();
}

