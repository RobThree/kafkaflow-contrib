IF NOT EXISTS(SELECT * FROM sys.schemas WHERE name = 'outbox')
BEGIN
	EXEC ('CREATE SCHEMA [outbox] AUTHORIZATION [dbo]')
END
GO
