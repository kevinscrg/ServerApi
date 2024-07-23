using System.ComponentModel.DataAnnotations;

namespace ServerApi.Models
{
    public class Gen
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nume { get; set; } 


        public List<Carte>? Carti { get; set; } = new List<Carte>();
    }
}
