namespace Trade.Ingestion.API.Models
{
    /// <summary>
    /// Represents a single aggregated data record for a specific account and symbol 
    /// within a trade report.
    /// </summary>
    public class TradeReportRow
    {
        /// <summary>
        /// The unique identifier for the trading account (e.g., "ACC-123").
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// The ticker or symbol of the financial instrument (e.g., "MSFT").
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// The total accumulated quantity of the instrument traded during the period.
        /// </summary>
        public required int TotalQty { get; set; }

        /// <summary>
        /// The volume-weighted average price of all trades executed for this symbol.
        /// </summary>
        public required decimal AvgPrice { get; set; }

        /// <summary>
        /// The total value of the position (Quantity × Price) expressed in the account's base currency.
        /// </summary>
        public required decimal NotionalBase { get; set; }

        /// <summary>
        /// The three-letter ISO currency code for the account (e.g., "USD").
        /// </summary>
        public required string BaseCcy { get; set; }
    }
}
