using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dot.Net.WebApi.Domain
{
    public class BidList
    {
        [JsonIgnore]
        public int BidListId { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Account { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string BidType { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit être un nombre décimal")]
        public double? BidQuantity { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit être un nombre décimal")]
        public double? AskQuantity { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit être un nombre décimal")]
        public double? Bid { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit être un nombre décimal")]
        public double? Ask { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Benchmark { get; set; }
        public DateTime? BidListDate { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Commentary { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string BidSecurity { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string BidStatus { get; set; }
        [Required(ErrorMessage = "{0} doit être rempli")]
        [MinLength(2, ErrorMessage = "{0} doit contenir au minimum 2 caractètres")]
        public string Trader { get; set; }
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