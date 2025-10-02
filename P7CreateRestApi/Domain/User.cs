using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace P7CreateRestApi.Domain
{
    public class User : IdentityUser
    {
        [NotMapped]
        public string Password { get; set; }
        public string Fullname { get; set; }
    }
}
