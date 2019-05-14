CREATE PROCEDURE [dbo].[sp_ContaCorrente_Transfer]
	 @BancoOri int
	,@AgenciaOri int
	,@ContaOri int
	,@DigitoOri int
	,@BancoDes int
	,@AgenciaDes int
	,@ContaDes int
	,@DigitoDes int

AS
begin

	declare @idOri int, @IdDes int

	select @idOri = id from ContaCorrente 
		where Banco = @BancoOri
			and Agencia = @AgenciaOri
			and Conta = @ContaOri
			and Digito = @DigitoOri
	
	if @idOri is null
	begin
		insert into ContaCorrente (ClienteId, Banco, Agencia, Conta, Digito, Saldo) values (1, @BancoOri, @AgenciaOri, @ContaOri, @DigitoOri, 0)

		select @idOri = @@IDENTITY 
	end
	
	
	
	select @idDes = id from ContaCorrente 
		where Banco = @BancoDes
			and Agencia = @AgenciaDes
			and Conta = @ContaDes
			and Digito = @DigitoDes
	
	if @idDes is null
	begin
		insert into ContaCorrente (ClienteId, Banco, Agencia, Conta, Digito, Saldo) values (2, @BancoDes, @AgenciaDes, @ContaDes, @DigitoDes, 0)

		select @idDes = @@IDENTITY 
	end
	
	select @idOri ContaCorrenteOri, @idDes ContaCorrenteDes

end
