using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.CreateDtos
{
    public class CreateRecenzieDto
    {

        public string Text { get; set; }


        [Required]
        [Range(0.0f, 5.0f)]
        public float Rating { get; set; }

        [Required]
        public int CarteId { get; set; }


        [Required]
        public int UserId { get; set; }
    }
}
