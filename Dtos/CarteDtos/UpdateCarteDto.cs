using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.CarteDtos
{
    public class UpdateCarteDto
    {
        public int Id { get; set; }


        public string Link { get; set; }


        [Required]
        public string Descriere { get; set; }


        public double Pret { get; set; }


        public List<int> GenuriId { get; set; }


        public List<int> TropeuriId { get; set; }
    }
}
