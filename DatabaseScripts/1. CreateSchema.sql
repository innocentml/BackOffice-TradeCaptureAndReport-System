IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Trading')
BEGIN
    EXEC('CREATE SCHEMA Trading')
END;