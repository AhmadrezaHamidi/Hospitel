using System.ComponentModel.DataAnnotations;

namespace Clinic_management_api.DtoModels;

public class ReservationDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DoctorId { get; set; }
    public string UserFullName { get; set; }
    public string DoctorFullName { get; set;}
    [MaxLength(50)]
    public string ExaminationStartTime { get; set; }

    [MaxLength(50)]
    public string ExaminationEndTime { get; set; }
    
    public bool PatientVisitStatus { get; set; }
}