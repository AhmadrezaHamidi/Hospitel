using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Hospital.Repository;
using Hospital.Services;
using Hospital.Infrastructure.UnitOfWork;
using Hospital.Core;

namespace Hospital.Services;

public class DoctorRepository
{

    GenericUnitOfWork<DoctorEntity> unitOfWork;
    GenericRepository<DoctorEntity> db;

    public DoctorRepository()
    {
        unitOfWork = new GenericUnitOfWork<DoctorEntity>();
        db = unitOfWork.GenericRepository;
    }

    public List<DoctorEntity> GetAll()
    {
        return db.Get().ToList();
    }


    public DoctorEntity GetDoctorByUserName(string firstName,string lastName)
    {
        return  db.Get(x => x.FirstName.Equals(firstName) && x.LastName.Equals(x.LastName))
        .FirstOrDefault();
    }

    public DoctorEntity GetDoctorById(string id)
    {
        return db.Get().First(x => x.Id.Equals(id));
    }
    public DoctorEntity GetFirstById(string id)
    {
        var res =db.GetRowById(id); 
        return  res;
    }

    public string AddDoctor (DoctorEntity doctor)
    {
        db.InsertRow(doctor);
        return doctor.Id.ToString();
    }

    public void DeleteRow (string id)
    {
        db.DeleteRowById(id);
    }

    public void EditDoctor (DoctorEntity doctor)
    {
        db.EditRow(doctor);
    }
}
