using Currency.Exchange.Service.Models;
using System.ServiceModel;

namespace Currency.Exchange.Service.Contract
{
    /// <summary>
    /// Defines the service contract for currency exchange operations, 
    /// enabling cross-system communication via WAF/WCF protocols.
    /// </summary>
    [ServiceContract(Namespace = "http://tempuri.org", Name = "ICurrencyExchangeService")]
    public interface ICurrencyExchangeService
    {
        /// <summary>
        /// Calculates or retrieves the current exchange rate for a specific currency pair.
        /// </summary>
        /// <param name="request">A <see cref="RateRequest"/> containing the source and target currency details.</param>
        /// <returns>The exchange rate as a <see cref="decimal"/> if successful; otherwise, <c>null</c>.</returns>
        [OperationContract(Action = "http://tempuri.orgICurrencyExchangeService/GetRate")]
        decimal? GetRate(RateRequest request);
    }
}