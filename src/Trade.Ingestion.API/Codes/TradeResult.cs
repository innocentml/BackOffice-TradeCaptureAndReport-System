namespace Trade.Ingestion.API.Codes
{
    /// <summary>
    /// Represents the final outcome of a trade processing operation.
    /// </summary>
    public enum TradeResult
    {
        /// <summary>
        /// The trade was successfully validated and persisted to the database.
        /// </summary>
        Success = 0,

        /// <summary>
        /// The trade processing failed. This may be due to validation errors, 
        /// missing accounts, or database connectivity issues.
        /// </summary>
        Failure = 1,

        /// <summary>
        /// The trade was rejected because the specified Account or Symbol 
        /// could not be found in the system.
        /// </summary>
        NotFound = 2,

        /// <summary>
        /// An unexpected internal error occurred during the trade execution.
        /// </summary>
        InternalError = 3
    }
}
