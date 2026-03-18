namespace Trade.Ingestion.API.Models
{
    /// <summary>
    /// Represents the configuration details for a specific database instance.
    /// </summary>
    public class DatabaseInstance
    {
        /// <summary>
        /// The full SQL connection string used to connect to the database server.
        /// </summary>
        public required string ConnectionString { get; set; }

        /// <summary>
        /// The unique name or identifier of the database (e.g., "TradeDataDB").
        /// </summary>
        public required string DatabaseName { get; set; }
    }
}
