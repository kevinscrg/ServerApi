using System.ComponentModel.DataAnnotations;

namespace ServerApi.Models
{
    public class User
    {
        public int Id { get; set; }


        [Required]
        public bool verificat { get; set; } = false;


        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string Parola { get; set; } = string.Empty;


        public List<Recenzie> Recenzii { get; set; } = new List<Recenzie>();


        public string? Nume { get; set; }
    }
}
