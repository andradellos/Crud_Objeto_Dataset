-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Emanuel Andrade>
-- Create date: <Create Date,14/11/2021>
-- Description:	<Trazer Objeto Pessos>
-- =============================================
CREATE PROCEDURE ObjetoPessoa
    @IdPessoa int ,
	@CarregaEndereco varchar(1), 
	@CarregaContatos varchar(1),
	@CarregaPessoa varchar(1)
	
AS
DECLARE @GerNomeCompleto VARCHAR(100);
BEGIN

		IF   
		   (@CarregaEndereco) = 'S'
		   BEGIN
			SELECT * FROM Endereco WHERE IdPessoa = @IdPessoa AND Status = 'A'
		   END
		IF 
		   (@CarregaContatos) = 'S'
		   BEGIN 
			SELECT * FROM Contatos WHERE IdPessoa = @IdPessoa AND Status = 'A'
		   END
		IF 
		   (@CarregaPessoa) = 'S'
		   BEGIN   
			 SELECT * FROM Pessoa WHERE IdPessoa = @IdPessoa AND Status = 'A'
		   END
END
GO