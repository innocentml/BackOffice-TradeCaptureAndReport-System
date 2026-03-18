using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Trade.Ingestion.API.Codes;
using Trade.Ingestion.API.Models;

namespace Trade.Ingestion.API.Persistence
{
    /// <summary>
    /// Provides the concrete implementation for managing trade records and reporting 
    /// within the Trade database.
    /// </summary>
    public class TradeDataDB : ITradeDataDB
    {
        /// <summary>
        /// The connection service used to retrieve SQL connection strings for specific databases.
        /// </summary>
        private readonly IDConnection dConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="TradeDataDB"/> class with a connection provider.
        /// </summary>
        /// <param name="dConnection">The <see cref="IDConnection"/> used to resolve connection strings by name.</param>
        public TradeDataDB(IDConnection dConnection)
        {
            this.dConnection = dConnection;
        }

        /// <inheritdoc />
        public async Task<TradeReportResponse> GenerateReport(TradeReportRequest tradeReportRequest)
        {
            var connectionString = dConnection.GetConnectionStringAsync("TradeDataDB");
            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FromDate", tradeReportRequest.FromDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@ToDate", tradeReportRequest.ToDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@AccountNumber", tradeReportRequest.AccountNumber, DbType.String, ParameterDirection.Input);

                try
                {
                    await connection.OpenAsync();
                    var results = (await connection.QueryAsync<dynamic>(
                        "Trading.GetAccountTradeReport",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    )).ToList();

                    TradeReportResponse response = null!;

                    if (results.Any())
                    {
                        response = new TradeReportResponse
                        {
                            From = results.First().ReportFrom,
                            To = results.First().ReportTo,
                            Rows = results.Select(r => new TradeReportRow
                            {
                                Account = r.account,
                                Symbol = r.symbol,
                                TotalQty = (int)r.total_qty,
                                AvgPrice = r.avg_price,
                                NotionalBase = r.notional_base,
                                BaseCcy = r.base_ccy
                            }).ToList()
                        };
                    }

                    return response;
                }
                catch (Exception exception)
                {
                    //Logging can be done here.
                    Console.WriteLine(exception.Message);

                    throw;
                }
            }
        }

        /// <inheritdoc />
        public async Task<TradeResult> ProcessTrade(TradeRequest tradeRequest)
        {
            var connectionString = dConnection.GetConnectionStringAsync("TradeDataDB");
            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AccountNumber", tradeRequest.Account, DbType.String, size: 50);
                parameters.Add("@Symbol", tradeRequest.Symbol, DbType.String, size: 20);
                parameters.Add("@Quantity", tradeRequest.Quantity, DbType.Decimal, precision: 18, scale: 4);
                parameters.Add("@Price", tradeRequest.Price, DbType.Decimal, precision: 18, scale: 4);
                parameters.Add("@TradeDate", tradeRequest.TradeTime, DbType.DateTime2);

                try
                {
                    await connection.OpenAsync();
                    var results = await connection.ExecuteAsync("Trading.ProcessTrade", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception exception)
                {
                    //Logging can be done here.
                    Console.WriteLine(exception.Message);

                    return TradeResult.Failure;
                }
            }

            return TradeResult.Success; 
        }
    }
}
