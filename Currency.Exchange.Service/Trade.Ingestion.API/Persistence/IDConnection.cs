namespace Trade.Ingestion.API.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDConnection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetConnectionStringAsync(string databaseName);

    }
}
