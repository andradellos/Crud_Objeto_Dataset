



EXECUTE  ObjetoPessoa  @CarregaEndereco='S', @CarregaContatos='S', @CarregaPessoa='N', @IdPessoa = 2

SELECT * FROM Endereco WHERE IdPessoa = 2 AND Status = 'A'


DROP procedure ObjetoPessoa




ALTER TABLE Endereco
ADD tabela varchar(100);

ALTER TABLE Endereco
ADD CONSTRAINT df_Endereco
DEFAULT 'Endereco' FOR tabela;

update Pessoa set tabela = 'Pessoa'

select * from Pessoa
select * from Contatos
select * from Endereco




