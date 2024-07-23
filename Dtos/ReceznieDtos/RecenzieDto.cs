using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.ReceznieDtos
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
        [Range(0.0f, 5.0f)]
        public float Rating { get; set; }
    }
}
