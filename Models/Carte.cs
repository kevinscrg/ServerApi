using System.ComponentModel.DataAnnotations;

namespace ServerApi.Models
{
    public class Carte
    {
        public int Id { get; set; }

        [Required]
        public string Titlu { get; set; } = string.Empty;


        [Required]
        public string Isbn { get; set; } = string.Empty;
        
        
        public int NrPagini { get; set; }
        
        
        public DateOnly DataAparitie { get; set; }
        
        
        public string? Link { get; set; }


        [Required]
        public string Descriere { get; set; } = string.Empty;


        [Required]
        public string Poza { get; set; } = string.Empty;
        
        
        public double Pret { get; set; }


        [Range(0.0, 5.0)]
        public float? Rating { get; set; }


        public List<Recenzie> Recenzii { get; set; }  = new List<Recenzie>();


        public List<Gen> Genuri { get; set; } = new List<Gen>();
        
        
        public List<Trope> Tropeuri { get; set; } = new List<Trope>();
    }
}
