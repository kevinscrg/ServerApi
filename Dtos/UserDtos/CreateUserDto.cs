using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.UserDtos
{
    public class CreateUserDto
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Parola { get; set; }


        [Required]
        public string ConfirmareParola { get; set; }


        public string? Nume { get; set; }
    }
}
