using Currency.Exchange.Service.Models;

namespace Currency.Exchange.Service.Contract
{
    /// <summary>
    /// Provides concrete logic for calculating currency exchange rates and conversions.
    /// </summary>
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        /// <summary>
        /// Retrieves the current exchange rate between two currencies based on the provided request.
        /// </summary>
        /// <param name="request">The <see cref="RateRequest"/> containing the source and target currency codes.</param>
        /// <returns>
        /// A <see cref="decimal"/> representing the exchange rate if found; 
        /// otherwise, <c>null</c> if the request is invalid or missing required currency codes.
        /// </returns>
        /// <inheritdoc/>
        public decimal? GetRate(RateRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.FromCurrency) || string.IsNullOrWhiteSpace(request.ToCurrency))
            {
                return null;
            }

            // TODO: Replace hardcoded rate with real-time API or database lookup
            return 1.02m;
        }
    }
}
