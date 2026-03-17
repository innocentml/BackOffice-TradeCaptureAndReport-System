
namespace Trade.Ingestion.API.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrencyExchangeDB : ICurrencyExchangeDB
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDConnection dConnection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dConnection"></param>
        public CurrencyExchangeDB(IDConnection dConnection)
        {
            this.dConnection = dConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task GenerateReport(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
