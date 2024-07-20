using System.ComponentModel.DataAnnotations;

namespace ServerApi.DTOs
{
    public enum StatusRecenzie
    {
        Aprobata,
        InAsteptare,
        Refuzata
    }
    public class RecenzieDto
    {
        [Required]
        public StatusRecenzie Status { get; set; }


        [Required]
        public int IdUser { get; set; }


        public string Text { get; set; }


        [Required]
        [Range(0.0, 5.0)]
        public float Rating { get; set; }

        [Required]
        public int IdCarte { get; set; }
    }
}
