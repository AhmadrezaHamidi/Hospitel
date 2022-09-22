
using Hospital.SharedKernel;

namespace Hospital.Core
{
    public class DoctorEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }

        public DoctorEntity(string firstName, string lastName, string specialty)
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            IsDeleted = false;
            FirstName = firstName;
            LastName = lastName;
            Specialty = specialty;
        }
    }
}