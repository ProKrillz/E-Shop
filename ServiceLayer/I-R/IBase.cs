using System.Linq.Expressions;

namespace ServiceLayer.I_R;

public interface IBase<T>
{
    Task<T> FindByIdAsync(int id);
    Task<int> CommitAsync();
    Task AddItemAsync(T entity);
    Task UpdateItemAsync(T entity);
    IQueryable<T> FindAll(Expression<Func<T, bool>> expression);
    IQueryable<T> FindAll();
    void Delete(T entity);
    IQueryable<T> FindAllPage(IQueryable<T> query, int currentpage, int pageSize);
    int Count();
}
