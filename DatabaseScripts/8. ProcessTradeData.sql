CREATE PROCEDURE Trading.ProcessTrade
    @AccountNumber NVARCHAR(50),
    @Symbol NVARCHAR(20),
    @Quantity DECIMAL(18, 4),
    @Price DECIMAL(18, 4),
    @TradeDate DATETIME2 = NULL -- Optional, defaults to now if NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @AccountId INT;
    DECLARE @InstrumentId INT;

    -- 1. Find the internal AccountId
    SELECT @AccountId = AccountId FROM Trading.Accounts WHERE AccountNumber = @AccountNumber;
    
    -- 2. Find the internal InstrumentId
    SELECT @InstrumentId = InstrumentId FROM Trading.Instruments WHERE Symbol = @Symbol;

    -- 3. Validation: Ensure both exist
    IF @AccountId IS NULL
    BEGIN
        RAISERROR('Account %s not found.', 16, 1, @AccountNumber);
        RETURN;
    END

    IF @InstrumentId IS NULL
    BEGIN
        RAISERROR('Symbol %s not found.', 16, 1, @Symbol);
        RETURN;
    END

    -- 4. Insert the Trade
    INSERT INTO Trading.Trades (AccountId, InstrumentId, Quantity, Price, TradeDate)
    VALUES (@AccountId, @InstrumentId, @Quantity, @Price, ISNULL(@TradeDate, GETDATE()));

    -- Return the newly created Trade ID
    SELECT SCOPE_IDENTITY() AS NewTradeId;
END;