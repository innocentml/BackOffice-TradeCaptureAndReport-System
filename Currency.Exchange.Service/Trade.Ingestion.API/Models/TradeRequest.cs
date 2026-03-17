using System.Runtime.Serialization;

namespace Trade.Ingestion.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TradeRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public required string ExternalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public required string Side { get; set; } // Consider an Enum for BUY/SELL

        /// <summary>
        /// 
        /// </summary>
        public required int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public required decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public required DateTime TradeTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public required string Currency { get; set; }
    }
}
