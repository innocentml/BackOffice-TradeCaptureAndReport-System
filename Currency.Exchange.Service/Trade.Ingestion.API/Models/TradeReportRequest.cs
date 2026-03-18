namespace Trade.Ingestion.API.Models
{
    /// <summary>
    /// Represents the input criteria used to filter and generate a specific trade activity report.
    /// </summary>
    public class TradeReportRequest
    {
        /// <summary>
        /// The starting date and time for the reporting period (inclusive).
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// The ending date and time for the reporting period (inclusive).
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// The unique account identifier for which the report is being requested.
        /// </summary>
        public required string AccountNumber { get; set; }
    }
}
