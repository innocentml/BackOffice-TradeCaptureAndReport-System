using Currency.Exchange.Service.Models;

namespace Currency.Exchange.Service.Contract
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        /// <inheritdoc/>
        public decimal? GetRate(RateRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.FromCurrency) || string.IsNullOrWhiteSpace(request.ToCurrency))
            {
                return null;
            }
            return 1.02m;
        }
    }
}
