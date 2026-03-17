using System.Runtime.Serialization;

namespace Currency.Exchange.Service.Models
{
    [DataContract(Namespace = "http://tempuri.org")]
    public class RateRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Order = 1)]
        public required string FromCurrency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Order = 2)]
        public required string ToCurrency { get; set; }
    }
}
