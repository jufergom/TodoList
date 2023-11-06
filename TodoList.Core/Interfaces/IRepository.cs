using System.Linq.Expressions;

namespace Namespace;

public interface IRepository<T>  where T : class
{
    IQueryable<T> GetAll();
    T GetById(int id);
    IQueryable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void SaveChanges();
}