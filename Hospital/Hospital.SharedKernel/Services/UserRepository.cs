using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Hospital.Repository;
using Hospital.Services;
using Hospital.Core;
using Hospital.Infrastructure.UnitOfWork;

namespace Hospital.Services;

public class UserRepository
{

    GenericUnitOfWork<UserEntity> unitOfWork;
    GenericRepository<UserEntity> db;

    public UserRepository()
    {
        unitOfWork = new GenericUnitOfWork<UserEntity>();
        db = unitOfWork.GenericRepository;
    }

    public List<UserEntity> GetAll()
    {
        return db.Get().ToList();
    }

    public UserEntity GetUser(string id)
    {
        return db.GetRowById(id);
    }

    public bool IsNotExist(string firstName, string lastName)
    {
        return db.Get(x => x.NationaCode.Equals(firstName) && x.LastName.Equals(lastName)).Any();
    }
    public bool IsExistByNationaCode(string nationaCode)
    {
        return db.Get(x => x.NationaCode.Equals(nationaCode)).Any();
    }

    public string AddUser(UserEntity user)
    {
        db.InsertRow(user);
        return user.Id.ToString();
    }

    public void DeleteUse(string id)
    {
        db.DeleteRowById(id);
    }

    public void EditUser(UserEntity user)
    {
        db.EditRow(user);
    }
}



