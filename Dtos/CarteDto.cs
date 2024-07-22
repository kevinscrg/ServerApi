using ServerApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos
{
    public class CarteDto
    {

        public int Id { get; set; }

        [Required]
        public string Titlu { get; set; }


        [Required]
        public string Isbn { get; set; }


        public int NrPagini { get; set; }


        public DateOnly DataAparitie { get; set; }


        public string Link { get; set; }


        [Required]
        public string Descriere { get; set; }


        [Required]
        public string Poza { get; set; }


        public double Pret { get; set; }


        public float Rating { 
            get {
                if (RecenziiRating != null && RecenziiRating.Any())
                {
                    return RecenziiRating.Average();
                }
                return 0;
            } 
        }


        public List<string> Genuri { get; set; } 


        public List<string> Tropeuri { get; set; }


        public List<string> RecenziiText { get; set; }


        
        public List<float> RecenziiRating { get; set; }
    }   
}
