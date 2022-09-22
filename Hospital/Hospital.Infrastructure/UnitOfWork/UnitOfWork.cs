using Hospital.Services;
using Hospital.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Hospital.SharedKernel;

namespace Hospital.Infrastructure.UnitOfWork;
public class GenericUnitOfWork<TEntity> : IDisposable where TEntity : BaseEntity
{
    private ApplicationContext _context = new ApplicationContext();

    private GenericRepository<TEntity> _repository;

    public GenericRepository<TEntity> GenericRepository
    {
        get
        {
            if (_repository == null)
            {
                _repository = new GenericRepository<TEntity>(_context);
            }
            return _repository;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChang()
    {
        _context.SaveChanges();
    }
}