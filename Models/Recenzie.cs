using System.ComponentModel.DataAnnotations;

namespace ServerApi.Models
{
    public class Recenzie
    {
        [Required]
        public string Status { get; set; }


        [Required]
        public int IdUser { get; set; }

        
        public string Text { get; set; }


        [Range(0.0, 5.0)]
        [Required]
        public float Rating { get; set; }

        [Required]
        public int IdCarte { get; set; }
    }
}
