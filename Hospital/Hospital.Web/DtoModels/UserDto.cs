using System.ComponentModel.DataAnnotations;

namespace Hospital.DtoModels;

public class UserDto
{
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(50)]
    public int NationaCode { get; set; }

    public int TrackingCode { get; set; }
}
