CREATE PROCEDURE [dbo].[sp_contacorrente_si]
	@Clienteid int
	,@Banco int
	,@Agencia int
	,@Conta int
	,@Digito int
	,@Saldo decimal(18,2) = 0
AS
begin

	declare @id int

	select @id = id from ContaCorrente 
		where ClienteId = @Clienteid 
			and Banco = @Banco
			and Agencia = @Agencia
			and Conta = @Conta
			and Digito = @Digito
	
	if @id is null
	begin
		insert into ContaCorrente (ClienteId, Banco, Agencia, Conta, Digito, Saldo) values (@Clienteid, @Banco, @Agencia, @Conta, @Digito, @Saldo)

		select @@IDENTITY Id
	end
	else
	begin
		select @Id Id
	end
end
