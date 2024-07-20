using System.ComponentModel.DataAnnotations;

namespace ServerApi.DTOs
{
    public class UserDto
    {

        [Required]
        public string UserName { get; set; }


        [Required]
        public string Parola { get; set; }


        public string? Nume { get; set; }
    }
}
