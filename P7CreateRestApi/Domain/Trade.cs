using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dot.Net.WebApi.Domain
{
    public class Trade
    {
        [JsonIgnore]
        public int TradeId { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Account { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string AccountType { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? BuyQuantity { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? SellQuantity { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? BuyPrice { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? SellPrice { get; set; }
        public DateTime? TradeDate { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string TradeSecurity { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string TradeStatus { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Trader { get; set; }
        [Required(ErrorMessage = "{0} doit �tre rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caract�tres")]
        public string Benchmark { get; set; }
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