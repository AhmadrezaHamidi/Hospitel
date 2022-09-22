using System.ComponentModel.DataAnnotations;

namespace Hospital.DtoModels.UserDtos
{
    public class RegisterUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NationaCode { get; set; }
    }


    public class RegisteDoctorDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Specialty { get; set; }
    }


    public class CreateShiftDto
    {
        [Required]
        public int WorkDay { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }

    }





}