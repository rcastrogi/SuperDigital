CREATE TABLE [dbo].[ContaCorrente]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ClienteId] INT NOT NULL, 
    [Banco] INT NOT NULL, 
    [Agencia] INT NOT NULL, 
    [Conta] INT NOT NULL, 
    [Digito] INT NOT NULL, 
    [Saldo] DECIMAL(18, 2) NOT NULL DEFAULT 0
)
