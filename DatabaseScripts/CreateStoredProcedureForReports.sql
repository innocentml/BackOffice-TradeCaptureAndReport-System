CREATE PROCEDURE Trading.GetAccountTradeReport
    @FromDate DATETIME2,
    @ToDate DATETIME2,
    @AccountNumber NVARCHAR(50) -- Filter for specific account
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        @FromDate AS [from],
        @ToDate AS [to],
        (
            SELECT 
                a.AccountNumber AS [account],
                i.Symbol AS [symbol],
                SUM(t.Quantity) AS [total_qty],
                CAST(SUM(t.Quantity * t.Price) / SUM(t.Quantity) AS DECIMAL(18,2)) AS [avg_price],
                CAST(SUM(t.Quantity * t.Price) AS DECIMAL(18,2)) AS [notional_base],
                a.BaseCurrency AS [base_ccy]
            FROM Trading.Trades t
            JOIN Trading.Accounts a ON t.AccountId = a.AccountId
            JOIN Trading.Instruments i ON t.InstrumentId = i.InstrumentId
            WHERE t.TradeDate >= @FromDate 
              AND t.TradeDate <= @ToDate
              AND a.AccountNumber = @AccountNumber -- Specific account filter
            GROUP BY a.AccountNumber, i.Symbol, a.BaseCurrency
            FOR JSON PATH
        ) AS [rows]
    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER;
END;