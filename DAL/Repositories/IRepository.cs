namespace DAL.Repositories;

public interface IRepository<T>
{
    public IEnumerable<T> GetAll();
    public void Create(T item);
    public void CreateRange(IEnumerable<T> items);
    public void SaveChanges();
}

