using System.Linq.Expressions;
using TodoList.Infrastructure;

namespace Namespace;

public class Repository<T> : IRepository<T>  where T : class
{
    private readonly TodoListContext _context;

    public Repository(TodoListContext context) 
    {
        context = _context;
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
        var entity = _context.Set<T>().Find(id);
        if(entity == null)
        {
            throw new KeyNotFoundException();
        }
        return entity;
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
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
        throw new NotImplementedException();
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }
}
