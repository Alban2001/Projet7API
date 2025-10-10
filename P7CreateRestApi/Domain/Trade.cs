using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dot.Net.WebApi.Domain
{
    public class Trade
    {
        [JsonIgnore]
        public int TradeId { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Account { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string AccountType { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit être un nombre décimal")]
        public double? BuyQuantity { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit être un nombre décimal")]
        public double? SellQuantity { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit être un nombre décimal")]
        public double? BuyPrice { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit être un nombre décimal")]
        public double? SellPrice { get; set; }
        public DateTime? TradeDate { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string TradeSecurity { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string TradeStatus { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Trader { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Benchmark { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Book { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string CreationName { get; set; }
        public DateTime? CreationDate { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string RevisionName { get; set; }
        public DateTime? RevisionDate { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string DealName { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string DealType { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string SourceListId { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Side { get; set; }
    }
}