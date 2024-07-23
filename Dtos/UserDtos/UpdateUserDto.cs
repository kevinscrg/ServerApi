using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ServerApi.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Parola { get; set; }

        [Required]
        public string ConfirmareParola { get; set; }

        public string? Nume { get; set; }

    }
}
