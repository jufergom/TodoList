using System.Linq.Expressions;

namespace Namespace;

public interface IRepository<T>  where T : BaseEntity
{
    IQueryable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void SaveChanges();
}