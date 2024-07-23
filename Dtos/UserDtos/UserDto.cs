using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }


        [Required]
        public string Email { get; set; }


        [Required]
        public string Parola { get; set; }


        public List<int>? RecenziiId { get; set; }


        public string? Nume { get; set; }
    }
}
