using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public abstract class EFRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _table;

    public EFRepository(DbContext context)
    {
        _context = context;
        _table = context.Set<T>();
    }

    public virtual IEnumerable<T> GetAll() => _table;
    public virtual void Create(T item) => _table.Add(item);
    public virtual void CreateRange(IEnumerable<T> items) => _table.AddRange(items);
    public virtual void SaveChanges() => _context.SaveChanges();
}

