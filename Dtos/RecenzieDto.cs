using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos
{
    public enum StatusRecenzie
    {
        Aprobata,
        InAsteptare,
        Refuzata
    }
    public class RecenzieDto
    {
        public int Id { get; set; }

        [Required]
        public StatusRecenzie Status { get; set; }


        public string Text { get; set; }


        [Required]
        [Range(0.0, 5.0)]
        public float Rating { get; set; }
    }
}
