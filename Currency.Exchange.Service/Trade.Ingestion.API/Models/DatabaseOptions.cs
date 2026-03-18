namespace Trade.Ingestion.API.Models
{
    /// <summary>
    /// Represents the root configuration object for all database connection settings.
    /// Maps directly to the "DatabaseInstances" section in appsettings.json.
    /// </summary>
    public class DatabaseOptions
    {
        /// <summary>
        /// Gets or sets the collection of configured database instances, including 
        /// their connection strings and identifying names.
        /// </summary>
        public List<DatabaseInstance> DatabaseInstances { get; set; } = new();
    }
}
