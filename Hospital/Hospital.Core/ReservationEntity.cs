
using Hospital.Infrastructure;
using Hospital.SharedKernel;

namespace Hospital.Core
{
    public class ReservationEntity : BaseEntity
    {
        public string? UserId { get; set; }
        public string DoctorId { get; set; }
        public string ShiftId { get; set; }
        public bool IsDone { get; set; }
        public string TrackingCode { get; set; }
        public ReservationEntity(string userId, string doctorId, string shiftId)
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            IsDeleted = false;
            UserId = userId;
            DoctorId = doctorId;
            ShiftId = shiftId;
            IsDone = false;
            TrackingCode = TrackingCodeCreator.RandomTrackingCreator();
        }
    }
   
}


