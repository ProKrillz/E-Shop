using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ServiceLayer.I_R;

public abstract class RepositroyBase<T> : IBase<T> where T : class
{
    internal DbContext _context;
    readonly DbSet<T> _set;

    public RepositroyBase(DbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }
    public virtual async Task<T> FindByIdAsync(int id)
        => await _set.FindAsync(id);

    public virtual async Task<int> CommitAsync()
        => await _context.SaveChangesAsync();

    public virtual async Task AddItemAsync(T entity)
        => await _set.AddAsync(entity);
    
    public virtual async Task UpdateItemAsync(T entity)
        => _context.Update(entity);

    public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> expression)
        => _set.Where(expression);

    public virtual IQueryable<T> FindAll()
        => _set;

    public virtual void Delete(T entity)
        => _set.Remove(entity);

    public virtual IQueryable<T> FindAllPage(IQueryable<T> query, int currentpage, int pageSize)
        => query.Skip((currentpage - 1) * pageSize).Take(pageSize);

    public virtual int Count()
        => _set.Count();
}
