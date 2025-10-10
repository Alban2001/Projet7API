using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dot.Net.WebApi.Controllers
{
    public class RuleName
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Json { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Template { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string SqlStr { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string SqlPart { get; set; }
    }
}