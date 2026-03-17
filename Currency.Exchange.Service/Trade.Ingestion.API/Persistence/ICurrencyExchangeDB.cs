namespace Trade.Ingestion.API.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICurrencyExchangeDB
    {
        Task GenerateReport(DateTime startDate, DateTime endDate);
    }
}
