CREATE TABLE [dbo].Screenshots
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Image] IMAGE NULL, 
    [Current Date] DATETIME NULL
)
