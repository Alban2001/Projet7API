using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace P7CreateRestApi.Domain
{
    public class User : IdentityUser
    {
        [NotMapped]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Fullname { get; set; }
    }
}
