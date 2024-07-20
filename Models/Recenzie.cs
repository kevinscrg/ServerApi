using System.ComponentModel.DataAnnotations;

namespace ServerApi.Models
{
    public class Recenzie
    {
        public int Id { get; set; }


        [Required]
        public string Status { get; set; } = string.Empty;

        
        public string? Text { get; set; }


        [Range(0.0, 5.0)]
        [Required]
        public float Rating { get; set; }
    }
}
