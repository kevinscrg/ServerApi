using System.ComponentModel.DataAnnotations;

namespace ServerApi.Models
{
    public class User
    {
        public int Id { get; set; }


        [Required]
        public string UserName { get; set; } = string.Empty;


        [Required]
        public string Parola { get; set; } = string.Empty;


        public List<Recenzie>? Recenzii { get; set; }


        public string? Nume { get; set; }
    }
}
