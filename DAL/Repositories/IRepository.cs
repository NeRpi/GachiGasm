namespace DAL.Repositories;

public interface IRepository<T>
{
    public IQueryable<T> GetAll();
    public void Create(T item);
    public void CreateRange(IEnumerable<T> items);
    public void SaveChanges();
    public void Delete(T item);
    public void Update(T item);
    public T GetById(int id);
}

