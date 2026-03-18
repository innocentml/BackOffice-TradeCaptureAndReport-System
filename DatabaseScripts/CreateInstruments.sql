CREATE TABLE Trading.Instruments (
    InstrumentId INT PRIMARY KEY IDENTITY(1,1),
    Symbol NVARCHAR(20) NOT NULL UNIQUE,
    AssetName NVARCHAR(100)
);