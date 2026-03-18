using Trade.Ingestion.API.Codes;
using Trade.Ingestion.API.Models;

namespace Trade.Ingestion.API.Persistence
{
    /// <summary>
    /// Defines the data access contract for interacting with the Trade Database.
    /// Provides methods for generating trade reports and processing new trade executions.
    /// </summary>
    public interface ITradeDataDB
    {
        /// <summary>
        /// Validates and persists a new trade execution into the database.
        /// </summary>
        /// <param name="tradeRequest">The trade details including Account, Symbol, Quantity, and Price.</param>
        /// <returns>A <see cref="TradeResult"/> indicating whether the trade was successfully processed or why it failed.</returns>
        
        Task<TradeResult> ProcessTrade(TradeRequest tradeRequest);
        /// <summary>
        /// Generates a consolidated trade report based on the criteria provided in the request.
        /// </summary>
        /// <param name="tradeReportRequest">A <see cref="TradeReportRequest"/> object containing the date range and account filter.</param>
        /// <returns>A <see cref="TradeReportResponse"/> containing aggregated trade data and totals for the specific account.</returns>
        Task<TradeReportResponse> GenerateReport(TradeReportRequest tradeReportRequest);
    }
}
