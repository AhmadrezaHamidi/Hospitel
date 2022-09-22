using System.ComponentModel.DataAnnotations;

namespace Hospital.DtoModels;

public class DoctorDto
{
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(50)]
    public string Specialty { get; set; }
    
    public string WorkingDay { get; set; }
    public string StartOfWorking { get; set; }
    public string EndOfWorking { get; set; }
}