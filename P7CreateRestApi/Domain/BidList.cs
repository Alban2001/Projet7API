using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dot.Net.WebApi.Domain
{
    public class BidList
    {
        [JsonIgnore]
        public int BidListId { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Account { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string BidType { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? BidQuantity { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? AskQuantity { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? Bid { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? Ask { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Benchmark { get; set; }
        public DateTime? BidListDate { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Commentary { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string BidSecurity { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string BidStatus { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Trader { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Book { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string CreationName { get; set; }
        public DateTime? CreationDate { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string RevisionName { get; set; }
        public DateTime? RevisionDate { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string DealName { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string DealType { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string SourceListId { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Side { get; set; }
    }
}