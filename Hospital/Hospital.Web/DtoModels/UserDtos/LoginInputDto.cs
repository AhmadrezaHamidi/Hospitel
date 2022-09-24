using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.DtoModels.UserDtos
{
    public class LoginInputDto
    {
        [Required]
         public string NationaCode { get; set; }
        [Required]
        public string PassWord { get; set; }

    }
}