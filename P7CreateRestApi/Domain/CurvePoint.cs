using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dot.Net.WebApi.Domain
{
    public class CurvePoint
    {
        [JsonIgnore]
        public int Id { get; set; }
        public byte? CurveId { get; set; }
        public DateTime? AsOfDate { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? Term { get; set; }
        [RegularExpression(@"^\d+([.,]\d+)?$", ErrorMessage = "{0} doit �tre un nombre d�cimal")]
        public double? CurvePointValue { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}