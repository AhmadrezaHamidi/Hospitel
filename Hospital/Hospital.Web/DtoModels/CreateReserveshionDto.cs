using System.ComponentModel.DataAnnotations;

namespace Hospital.DtoModels;

public class CreateReserveshionDto
{
    [Required]
    public Guid userID { get; set; }

    [Required]
    public Guid doctorID { get; set; }


    private ReservationDateDto calender;

    public void SetCalender(ReservationDateDto value)
    {
        calender = value;
    }
}
