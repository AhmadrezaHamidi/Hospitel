using System.Linq.Expressions;

namespace Hospital.Repository;

public interface IRepository<TEntity>
{
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> navigationPropertyPath = null ,Expression<Func<TEntity, object>> SecondnavigationPropertyPath = null);
    TEntity GetRowById(string id);
    void InsertRow(TEntity obj);
    void DeleteRowById(string id);
    void EditRow(TEntity obj);
}
