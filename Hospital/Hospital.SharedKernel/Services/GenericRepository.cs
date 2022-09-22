using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Hospital.Repository;
using Hospital.Infrastructure.Data.Context;
using Hospital.SharedKernel;

namespace Hospital.Services;
public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private ApplicationContext _dbContext;
    private DbSet<TEntity> _dbSet;
    public GenericRepository(ApplicationContext DbContext)
    {
        _dbContext = DbContext;
        _dbSet = DbContext.Set<TEntity>();
    }


    public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> navigationPropertyPath = null, Expression<Func<TEntity, object>> SecondnavigationPropertyPath = null)
    {
        IQueryable<TEntity> qurey = _dbSet;

        if (where != null)
        {
            qurey = qurey.Where(where);

        }
        if (navigationPropertyPath != null)
        {
            qurey = qurey.Include(navigationPropertyPath);

        }
        if (SecondnavigationPropertyPath != null)
        {
            qurey = qurey.Include(SecondnavigationPropertyPath);

        }
        return qurey.ToList();
    }







    public async void DeleteRowById(string id)
    {
        var getResult = GetRowById(id);

        if (getResult != null)
        {
            _dbSet.Remove(getResult);
        }

        await _dbContext.SaveChangesAsync();
    }

    public virtual async void InsertRow(TEntity obj)
    {
        _dbSet.Add(obj);
        _dbContext.SaveChanges();
        await _dbContext.SaveChangesAsync();
    }

    public virtual async void EditRow(TEntity obj)
    {
        _dbSet.Update(obj);
        await _dbContext.SaveChangesAsync();
    }

    public TEntity GetRowById(string id)
    {
        var res = _dbSet.FirstOrDefault(predicate : x => x.Id.ToString().Equals(id));
        return res;
    }




   
    public TEntity GetQuerySteps(string id)
    {
        var res = _dbSet.ToList();
        var tt = res.Where(x => x.Id.ToString().Equals(id)).First();
        return tt;
    }


    public TEntity find(string id)
    {
        var res = _dbSet.Find(id);
        return res;
    }

}