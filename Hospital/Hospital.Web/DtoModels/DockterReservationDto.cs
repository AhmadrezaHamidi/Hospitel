using System.Security.AccessControl;
namespace Hospital.Web.DtoModels
{
    public class DockterReservationDto
    {
        public DockterReservationDto(List<ReservationDto> fullSinceList, List<ReservationDto> openSinceList)
        {
            FullSinceList = fullSinceList;
            OpenSinceList = openSinceList;
        }

        public List<ReservationDto> FullSinceList { get; set; }
        public List<ReservationDto> OpenSinceList { get; set; }
        
    }
    public class ReservationDto
    {
        public string DoctorId { get; set; }
        public ShiftReserveshionResultDto Shift { get; set; }
        public bool IsDone { get; set; }
    }
    public class ShiftReserveshionResultDto
    {
        public int WorkDay { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Sance { get; set; }
    }



}