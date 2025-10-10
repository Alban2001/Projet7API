using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dot.Net.WebApi.Controllers.Domain
{
    public class Rating
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string MoodysRating { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string SandPRating { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string FitchRating { get; set; }
        public byte? OrderNumber { get; set; }
    }
}