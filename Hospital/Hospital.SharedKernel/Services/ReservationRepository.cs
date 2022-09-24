
using Hospital.Core;
using Hospital.Infrastructure.UnitOfWork;

namespace Hospital.Services;

public class ReservationRepository
{
    GenericUnitOfWork<ReservationEntity> unitOfWork;
    GenericRepository<ReservationEntity> db;


    public ReservationRepository()
    {
        unitOfWork = new GenericUnitOfWork<ReservationEntity>();
        db = unitOfWork.GenericRepository;
    }

    public List<ReservationEntity> GetAll()
    {
        return db.Get().ToList();
    }

    // public List<ReservationDto> GetAllReservationDtos()
    // {
    //     var reservationDtoList = db
    //         .Get(navigationPropertyPath: a => a.UserId , SecondnavigationPropertyPath: a => a.DoctorId)
    //         .Select(s => new ReservationDto()
    //         {
    //             UserId = s.UserId,
    //             UserFullName = s. .FirstName + " " + s.User.LastName,
    //             DoctorId = s.DoctorId,
    //             DoctorFullName = s.Doctor.FirstName + " " + s.Doctor.LastName,
    //             ExaminationStartTime = s.ExaminationStartTime,
    //             ExaminationEndTime = s.ExaminationEndTime
    //         })
    //         .ToList();

    //     return reservationDtoList;
    // }

    // public ReservationEntity GetReservationById (Guid id)
    // {
    //     return db.GetRowById(id);
    // }

    public string AddReservation (ReservationEntity reservation)
    {
        db.InsertRow(reservation);
        return reservation.TrackingCode;

    }


    public ReservationEntity CheckReservation(string shiftId,string doctorId)
    {
        return db.Get(x => x.ShiftId.Equals(shiftId) && 
        x.DoctorId.Equals(doctorId))
        .FirstOrDefault();
    }

    public void DeleteReservation (string id)
    {
        db.DeleteRowById(id);
    }

    public void EditReservation (ReservationEntity reservation)
    {
        db.EditRow(reservation);
    }

    
}