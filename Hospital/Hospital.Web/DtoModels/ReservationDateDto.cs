using System.ComponentModel.DataAnnotations;

namespace Hospital.DtoModels;

public class ReservationDateDto
{
    [Required]
    public DateTime examinationStartTime { get; set; }
    [Required]
    public DateTime examinationEndTime { get; set; }
    [Required]
    public Calender Calender { get; set; }
        
}