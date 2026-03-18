CREATE Trading.TABLE Trades (
    TradeId INT PRIMARY KEY IDENTITY(1,1),
    AccountId INT NOT NULL,
    InstrumentId INT NOT NULL,
    Quantity DECIMAL(18, 4) NOT NULL,
    Price DECIMAL(18, 4) NOT NULL,
    TradeDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    
    -- Foreign Key Constraints
    CONSTRAINT FK_Trades_Accounts FOREIGN KEY (AccountId) 
        REFERENCES Accounts(AccountId),
    CONSTRAINT FK_Trades_Instruments FOREIGN KEY (InstrumentId) 
        REFERENCES Instruments(InstrumentId)
);