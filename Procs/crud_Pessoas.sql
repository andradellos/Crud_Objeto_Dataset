IF OBJECT_ID('crud_Pessoa') IS NOT NULL
BEGIN 
DROP PROC crud_Pessoa
END
GO
CREATE PROCEDURE crud_Pessoa
       @Acao varchar (1),
       @IdPessoa int,
	   @Nome varchar(70),
	   @Nascimento Date,
	   @Status	varchar(1)	   	 
AS
BEGIN

--c=CREATE, r=READ, u=UPDATE, d=DELETE, rsw READ SEM WHERE

  IF (@Acao) = 'c'
	 BEGIN
		INSERT INTO [dbo].[Pessoa](
			   Nome,
			   Nascimento,
			   Status,
			   tabela)
			VALUES (
			   @Nome,
			   @Nascimento,
			   @Status,
			   'Pessoa')
 
		SET @IdPessoa = SCOPE_IDENTITY()
 
		SELECT 
			   Nome = @Nome,
			   Nascimento = @Nascimento,
			   Status	= @Status
		FROM [dbo].[Pessoa] 
		WHERE  IdPessoa = @IdPessoa
	END

  IF (@Acao) = 'r'
	 BEGIN
	   	SELECT 
		       IdPessoa
			   Nome ,
			   Nascimento,
			   Status,
			   tabela
		FROM [dbo].[Pessoa]
		WHERE  IdPessoa = @IdPessoa
	 END

  IF (@Acao) = 'u'
	 BEGIN
	   UPDATE [dbo].[Pessoa]
	   SET Nome = @Nome,
		   Nascimento = @Nascimento,
		   Status = @Status
		WHERE  IdPessoa = @IdPessoa
	 END

  IF (@Acao) = 'd'
	 BEGIN
	  DELETE FROM [dbo].[Pessoa] WHERE IdPessoa = @IdPessoa
	 END

  IF (@Acao) = 'rsw'
	 BEGIN
	   	SELECT 
		       IdPessoa
			   Nome ,
			   Nascimento,
			   Status,
			   tabela
		FROM [dbo].[Pessoa]
	 END

END