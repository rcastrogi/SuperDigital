﻿/*
Deployment script for Bank

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Bank"
:setvar DefaultFilePrefix "Bank"
:setvar DefaultDataPath "C:\Users\castr\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\castr\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[sp_ContaCorrente_Transfer]...';


GO
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
GO
PRINT N'Update complete.';


GO
