CREATE TABLE [dbo].[Lancamento]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FromContaCorrenteId] INT NOT NULL, 
    [ToContaCorrenteId] INT NOT NULL, 
    [Valor] DECIMAL(18, 2) NOT NULL, 
    [DtLancto] DATETIME NOT NULL DEFAULT getdate(), 
    [Debito] BIT NOT NULL DEFAULT 0
)
