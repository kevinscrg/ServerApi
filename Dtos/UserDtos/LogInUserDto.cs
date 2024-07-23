using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.UserDtos
{
    public class LogInUserDto
    {
        [Required]
        public string Email { get; set; }


        [Required]
        public string Parola { get; set; }
    }
}
