using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using Trade.Ingestion.API.Codes;
using Trade.Ingestion.API.Models;
using Trade.Ingestion.API.Persistence;

namespace Trade.Ingestion.API.Controllers
{
    [Route("/Trade")]
    public class TradeController : Controller
    {
        /// <summary>
        /// The external service used to handle currency conversions and exchange rate lookups.
        /// </summary>
        private readonly ICurrencyExchangeService currencyService;

        /// <summary>
        /// The data access service for performing operations against the trade database.
        /// </summary>
        private readonly ITradeDataDB tradeDataDB;

        /// <summary>
        /// Initialises a new instance of the <see cref="TradeController"/> class.
        /// </summary>
        /// <param name="currencyService">The <see cref="ICurrencyExchangeService"/> instance.</param>
        /// <param name="tradeDataDB">The <see cref="ITradeDataDB"/> instance.</param>
        public TradeController(ICurrencyExchangeService currencyService, ITradeDataDB tradeDataDB)
        {
            this.currencyService = currencyService;
            this.tradeDataDB = tradeDataDB;
        }

        /// <summary>
        /// Receives and processes a new trade request, persisting it to the ledger.
        /// </summary>
        /// <param name="tradeRequest">The <see cref="TradeRequest"/> details.</param>
        /// <returns>A <see cref="TradeResult"/> indicating success or failure of the operation.</returns>
        [HttpPost]
        [Route("/api/v1/processtrade")]
        public async Task<TradeResult?> ProcessTrade([FromBody] TradeRequest tradeRequest)
        {
            try
            {
                var rate = await currencyService.GetRateAsync(new RateRequest { FromCurrency = "USD", ToCurrency = "EUR" });

                if (rate == null) 
                {
                    throw new Exception("Invalid rate returned.");
                }

                tradeRequest.Price = (decimal)rate * tradeRequest.Price;
            }
            catch (Exception)
            {
                return TradeResult.Failure;
            }


            return await tradeDataDB.ProcessTrade(tradeRequest);
        }

        /// <summary>
        /// Retrieves a filtered trade report based on the provided date range and account details.
        /// </summary>
        /// <param name="tradeReportRequest">The <see cref="TradeReportRequest"/> filtering criteria.</param>
        /// <returns>A <see cref="TradeReportResponse"/> containing aggregated trade activity.</returns>
        [HttpGet]
        [Route("/api/v1/report")]
        public async Task<TradeReportResponse?> GetTradeReport([FromQuery] TradeReportRequest tradeReportRequest)
        {
            return await tradeDataDB.GenerateReport(tradeReportRequest);
        }
    }
}
