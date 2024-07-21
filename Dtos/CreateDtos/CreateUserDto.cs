using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.CreateDtos
{
    public class CreateUserDto
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Parola { get; set; }

        public string? Nume { get; set; }
    }
}
