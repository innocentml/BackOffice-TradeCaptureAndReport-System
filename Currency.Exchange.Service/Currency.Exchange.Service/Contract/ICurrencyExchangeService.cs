using Currency.Exchange.Service.Models;
using System.ServiceModel;

namespace Currency.Exchange.Service.Contract
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract(Namespace = "http://tempuri.org", Name = "ICurrencyExchangeService")]
    public interface ICurrencyExchangeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract(Action = "http://tempuri.orgICurrencyExchangeService/GetRate")]
        decimal? GetRate(RateRequest request);
    }
}
