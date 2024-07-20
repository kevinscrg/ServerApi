using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }


        [Required]
        public string UserName { get; set; }


        [Required]
        public string Parola { get; set; }


        public List<RecenzieDto>? Recenzii { get; set; }


        public string? Nume { get; set; }
    }
}
