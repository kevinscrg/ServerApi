using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.ReceznieDtos
{
    public class UpdateRecenzieDto
    {
        public int Id { get; set; }


        public string Text { get; set; }


        [Required]
        [Range(0.0f, 5.0f)]
        public float Rating { get; set; }
    }
}
