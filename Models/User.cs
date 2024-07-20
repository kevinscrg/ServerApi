using System.ComponentModel.DataAnnotations;

namespace ServerApi.Models
{
    public class User
    {
        public int Id { get; set; }


        [Required]
        public string UserName { get; set; }


        [Required]
        public string Parola { get; set; }


        public string? Nume { get; set; }
    }
}
