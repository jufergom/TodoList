using System.Linq.Expressions;
using TodoList.Infrastructure;

namespace Namespace;

public class Repository<T> : IRepository<T>  where T : BaseEntity
{
    private readonly TodoListContext _context;

    public Repository(TodoListContext context) 
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.AddRange(entities);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsQueryable();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
    }
}
