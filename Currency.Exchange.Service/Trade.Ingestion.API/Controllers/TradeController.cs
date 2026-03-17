using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using Trade.Ingestion.API.Models;

namespace Trade.Ingestion.API.Controllers
{
    [Route("/Trade")]
    public class TradeController : Controller
    {
        private readonly ICurrencyExchangeService currencyService;

        public TradeController(ICurrencyExchangeService currencyService) 
        {
            this.currencyService = currencyService;
        }

        [HttpPost]
        [Route("/api/v1/processtrade")]
        public async Task<decimal?> ProcessTrade(TradeRequest tradeRequest)
        {
            var response = await currencyService.GetRateAsync(new RateRequest { ToCurrency="sadsa", FromCurrency="sdsad"});

            return response;
        }

        [HttpGet]
        [Route("/api/v1/report")]
        public async Task<decimal?> GetTradeReport(TradeRequest tradeRequest)
        {
            var response = await currencyService.GetRateAsync(new RateRequest { ToCurrency = "sadsa", FromCurrency = "sdsad" });

            return response;
        }
    }
}
