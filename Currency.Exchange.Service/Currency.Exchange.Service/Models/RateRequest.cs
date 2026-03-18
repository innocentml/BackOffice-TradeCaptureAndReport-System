using System.Runtime.Serialization;

namespace Currency.Exchange.Service.Models
{
    /// <summary>
    /// Represents a data transfer object (DTO) used to request an exchange rate 
    /// between two specific currencies.
    /// </summary>
    [DataContract(Namespace = "http://tempuri.org")]
    public class RateRequest
    {
        /// <summary>
        /// The ISO 4217 code for the source currency (e.g., "USD").
        /// </summary>
        [DataMember(Order = 1)]
        public required string FromCurrency { get; set; }

        /// <summary>
        /// The ISO 4217 code for the target currency (e.g., "ZAR").
        /// </summary>
        [DataMember(Order = 2)]
        public required string ToCurrency { get; set; }
    }
}
