using Hospital.Infrastructure.UnitOfWork;
using Hospital.Core;

namespace Hospital.Services;

public class ShiftRepository
{
    GenericUnitOfWork<ShiftEntity> unitOfWork;
    GenericRepository<ShiftEntity> db;

    public ShiftRepository()
    {
        unitOfWork = new GenericUnitOfWork<ShiftEntity>();
        db = unitOfWork.GenericRepository;
    }

    public List<ShiftEntity> GetAll()
    {
        return db.Get().ToList();
    }

    public ShiftEntity GetShiftById(string id)
    {
        return db.GetRowById(id);
    }
    public ShiftEntity CheckShift(int workDay,DateTime start,DateTime end)
    {
        return  db.Get(x => x.WorkDay.Equals(workDay) && 
        x.Start.Hour.Equals(start.Hour) && x.End.Hour.Equals(end.Hour))
        .FirstOrDefault();
    }

    public string AddShift (ShiftEntity shift)
    {
        db.InsertRow(shift);
        return shift.Id.ToString();
    }

    public void DeleteRow (string id)
    {
        db.DeleteRowById(id);
    }

    public void EditDoctor (ShiftEntity shift)
    {
        db.EditRow(shift);
    }
}