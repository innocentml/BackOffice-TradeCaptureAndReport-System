namespace Trade.Ingestion.API.Models
{
    /// <summary>
    /// Represents the structured response for a trade activity report within a specific timeframe.
    /// </summary>
    public class TradeReportResponse
    {
        /// <summary>
        /// The start date and time of the reporting period, formatted as a string.
        /// </summary>
        public required DateTime From { get; set; }

        /// <summary>
        /// The end date and time of the reporting period, formatted as a string.
        /// </summary>
        public required DateTime To { get; set; }

        /// <summary>
        /// A collection of aggregated trade data records falling within the specified date range.
        /// </summary>
        public required List<TradeReportRow> Rows { get; set; } = new();
    }
}
