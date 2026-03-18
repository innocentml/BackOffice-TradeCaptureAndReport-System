CREATE TABLE Trading.Accounts (
    AccountId INT PRIMARY KEY IDENTITY(1,1),
    AccountNumber NVARCHAR(50) NOT NULL UNIQUE,
    BaseCurrency CHAR(3) NOT NULL
);