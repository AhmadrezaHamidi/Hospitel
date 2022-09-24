
using Hospital.SharedKernel;

namespace Hospital.Core
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationaCode { get; set; }
        public string? LastTrackingCode { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public UserEntity(string firstName, string lastName, string nationaCode,string password)
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            IsDeleted = false;
            FirstName = firstName;
            LastName = lastName;
            NationaCode = nationaCode;
            LastTrackingCode = null;
            Role = "user";
            Password =  password;
        }
    }
}