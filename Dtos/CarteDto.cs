using ServerApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ServerApi.DTOs
{
    public class CarteDto
    {
        [Required]
        public string Titlu { get; set; }


        [Required]
        public string Isbn { get; set; }


        public int NrPagini { get; set; }


        public DateOnly DataAparitie { get; set; }


        public string LinkAchizitionare { get; set; }


        [Required]
        public string Descriere { get; set; }


        [Required]
        public string Poza { get; set; }


        public double Pret { get; set; }


        [Range(0.0, 5.0)]
        public float? Rating { get; set; }


        public List<string> Gen { get; set; }


        public List<string> Tropeuri { get; set; }


        public List<Recenzie> Recenzii { get; set; }
    }
}
