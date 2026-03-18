namespace Trade.Ingestion.API.Models
{
    /// <summary>
    /// Represents the incoming request data for executing and recording a new trade transaction.
    /// </summary>
    public class TradeRequest
    {
        /// <summary>
        /// A unique identifier from the external source system to ensure idempotency and tracking.
        /// </summary>
        public required string ExternalId { get; set; }

        /// <summary>
        /// The account identifier responsible for the trade (e.g., "ACC-123").
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// The ticker or asset symbol being traded (e.g., "MSFT" or "BTC").
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// The direction of the trade, typically "BUY" or "SELL".
        /// </summary>
        public required string Side { get; set; }

        /// <summary>
        /// The number of units or shares involved in the transaction.
        /// </summary>
        public required int Quantity { get; set; }

        /// <summary>
        /// The execution price per unit of the instrument.
        /// </summary>
        public required decimal Price { get; set; }

        /// <summary>
        /// The specific date and time the trade was executed in the external system.
        /// </summary>
        public required DateTime TradeTime { get; set; }

        /// <summary>
        /// The currency code used for the transaction price (e.g., "USD").
        /// </summary>
        public required string Currency { get; set; }
    }
}
