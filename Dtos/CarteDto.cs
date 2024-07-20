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


        [Range(0.0, 5.0)]
        public float? Rating { get; set; }


        public List<GenDto> Genuri { get; set; }


        public List<TropeDto> Tropeuri { get; set; }


        public List<RecenzieDto> Recenzii { get; set; }
    }
}
