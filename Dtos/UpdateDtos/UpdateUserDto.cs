using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.UpdateDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }


        [Required]
        public string Parola { get; set; }


        public string? Nume { get; set; }
    }
}
