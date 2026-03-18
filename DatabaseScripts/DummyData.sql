USE TradeDataDB


-- 1. Populate Accounts
INSERT INTO Trading.Accounts (AccountNumber, BaseCurrency)
VALUES 
('ACC-123', 'USD'),
('ACC-456', 'GBP'),
('ACC-789', 'EUR');

-- 2. Populate Instruments
INSERT INTO Trading.Instruments (Symbol, AssetName)
VALUES 
('MSFT', 'Microsoft Corp'),
('AAPL', 'Apple Inc'),
('TSLA', 'Tesla Inc'),
('BTC', 'Bitcoin');

-- 3. Populate Trades (Linking AccountId and InstrumentId)
-- Note: Assuming IDs start at 1 based on IDENTITY(1,1)
INSERT INTO Trading.Trades (AccountId, InstrumentId, Quantity, Price, TradeDate)
VALUES 
(1, 1, 200, 305.00, '2025-01-15 10:30:00'), -- ACC-123 bought MSFT
(1, 1, 300, 310.83, '2025-01-15 14:45:00'), -- ACC-123 bought more MSFT
(1, 2, 100, 185.00, '2025-01-15 11:00:00'), -- ACC-123 bought AAPL
(2, 3, 50, 240.00,  '2025-01-16 09:15:00'), -- ACC-456 bought TSLA
(3, 4, 0.5, 45000.00, '2025-01-16 16:20:00'); -- ACC-789 bought BTC