using System.Security.AccessControl;
namespace Hospital.Web.DtoModels
{
    public class GetMyReserveshionDto
    {
        public GetMyReserveshionDto(List<MyReservationDto> doneReserVision, List<MyReservationDto> inComingReserVision)
        {
            DoneReserVision = doneReserVision;
            InComingReserVision = inComingReserVision;
        }

        public List<MyReservationDto> DoneReserVision { get; set; }
        public List<MyReservationDto> InComingReserVision { get; set; }
                
    }
    public class MyReservationDto
    {
        public string DoctorId { get; set; }
        public ShiftReserveshionResultDto Shift { get; set; }
        public bool IsDone { get; set; }
        public string TrackingCode { get; set; }

    }
 
}