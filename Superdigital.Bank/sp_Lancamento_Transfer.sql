CREATE PROCEDURE [dbo].[sp_Lancamento_Transfer]
	@FromContaCorrenteId int,
	@ToContaCorrenteId int,
	@Valor decimal(18,2)
AS
begin	
	begin transaction 
	begin try

		INSERT INTO dbo.Lancamento (FromContaCorrenteId, ToContaCorrenteId, Debito, Valor ) Values (@FromContaCorrenteId, @FromContaCorrenteId, 1, @Valor)
		UPDATE dbo.ContaCorrente set Saldo = Saldo - @Valor where Id = @FromContaCorrenteId

		INSERT INTO dbo.Lancamento (FromContaCorrenteId, ToContaCorrenteId, Debito, Valor ) Values (@FromContaCorrenteId, @ToContaCorrenteId, 0, @Valor)
		UPDATE dbo.ContaCorrente set Saldo = Saldo + @Valor where Id = @ToContaCorrenteId

		commit
	end try
	begin catch
		rollback
	end catch
end
