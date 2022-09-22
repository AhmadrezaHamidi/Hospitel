using System.ComponentModel.DataAnnotations;

namespace Hospital.DtoModels;

public class MakeReservationInputDto
{
    [Required]
    public string UserId { get; set; }
    [Required]
    public string DoctorId { get; set; }
    [Required]
    public string ShiftId { get; set; }
}
