using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace P7CreateRestApi.Domain
{
    public class User : IdentityUser
    {
        [NotMapped]
        [MinLength(8, ErrorMessage = "{0} doit contenir au minimum 8 caractètres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).+$",
        ErrorMessage = "Le mot de passe doit contenir au moins une lettre majuscule, une lettre minuscule, un chiffre et un caractère spécial.")]
        public string Password { get; set; }
        [NotMapped]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Fullname { get; set; }
        [EmailAddress(ErrorMessage = "{0} n'est pas valide.")]
        public string Email { get; set; }
    }
}
