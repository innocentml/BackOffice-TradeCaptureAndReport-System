namespace Trade.Ingestion.API.Persistence
{
    /// <summary>
    /// Provides a mechanism to retrieve connection strings for various databases 
    /// based on their configured names.
    /// </summary>
    public interface IDConnection
    {
        /// <summary>
        /// Retrieves the connection string associated with the specified database name from the application configuration.
        /// </summary>
        /// <param name="databaseName">The unique name of the database (e.g., "TradeDataDB") as defined in appsettings.json.</param>
        /// <returns>A <see cref="string"/> containing the full SQL connection string, including server and credentials.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if the specified database name is not found in the configuration.</exception>
        string GetConnectionStringAsync(string databaseName);
    }
}
