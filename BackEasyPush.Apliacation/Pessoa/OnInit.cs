using BackEasyPush.Domain;
using BackEasyPush.Infra.Data;
using BackEasyPush.Infra.Data.Pessoa;
using BackEasyPush.Infra.Data.Pessoas;
using System;
using System.Collections.Generic;
using static BackEasyPush.Domain.EmComum;
using static BackEasyPush.Infra.Data.Pessoas.ObjetoPessoa;

namespace BackEasyPush.Apliacation.Pessoa
{
    public class OnInit
    {
        ObjetoPessoa pessoaData = new ObjetoPessoa();
        CrudPessoa crudPessoa = new CrudPessoa();
        CrudContatos crudContato = new CrudContatos();

        public void Teste()
        {
            try
            {
                Domain.Pessoa pessoa = new Domain.Pessoa();

                //Por default as propriedades não serão carregadas caso necessite configure como está abaixo
                CarregarDados.Enderecos = valor.Sim;
                CarregarDados.Pessoa = valor.Sim;
                CarregarDados.Contatos = valor.Sim;
                //CarregarDados.Geral();

                pessoa = pessoaData.Carregar(3);
                int _cidade = pessoa?.Enderecos.Count > 0 ? pessoa.Enderecos[0].IdCidade : 0;

                string _numero = pessoa?.Contatos.Count > 0 ? pessoa?.Contatos?[0]?.Numero : string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert()
        {
            try
            {
                Domain.Pessoa pessoa = new Domain.Pessoa();
                pessoa.Nome = "Cara Mais Brabo";
                pessoa.Nascimento = DateTime.Now;
                pessoa.Status = "A";
                pessoa.IdPessoa = 0;

                int r = crudPessoa.Insert(pessoa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpDate()
        {
            try
            {
                Domain.Pessoa pessoa = new Domain.Pessoa();
                pessoa.Nome = "Numero Oito Update para I";
                pessoa.Nascimento = DateTime.Now;
                pessoa.Status = "I";
                pessoa.IdPessoa = 5;

                int r = crudPessoa.UpDate(pessoa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Select()
        {
            try
            {
                Domain.Pessoa InPessoa = new Domain.Pessoa();
                InPessoa.IdPessoa = 8;

                Domain.Pessoa OutPessoa = crudPessoa.Select(InPessoa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete()
        {
            try
            {
                Domain.Pessoa InPessoa = new Domain.Pessoa();
                InPessoa.IdPessoa = 1;

              int r =crudPessoa.Delete(InPessoa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SelectGeral()
        {
            try
            {
                List<Domain.Pessoa> OutPessoa = new List<Domain.Pessoa>();
                OutPessoa = crudPessoa.SelectGeral();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void InsertContato()
        {
            try
            {
                Contato contato = new Contato();
                contato.IdPessoa = 2;
                contato.Numero = "(79)2244-9855";
                contato.Status = "A";
                contato.Tipo = "Trabalho";

                int r = crudContato.Insert(contato);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void UpDateContato()
        {
            try
            {
                Contato contato = new Contato();
                contato.IdContato = 4;
                contato.IdPessoa = 3;
                contato.Numero = "(71)99968-6878";
                contato.Status = "A";
                contato.Tipo = "Pessoal";

                int r = crudContato.UpDate(contato);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SelectContatosGeral()
        {
            try
            {
                List<Contato> OutContato = new List<Contato>();
                OutContato = crudContato.SelectGeral();
            }
            catch (Exception)
            {
                throw;
            }
        }




        //  
        //1 - git init
        //2 - git remote add origin https://github.com/andradellos/Crud_Objeto_Dataset.git
        //3 - git add .
        //4 - git commit -m "first commit"

        //5 -  =====Caso queira criar um bench ====
        //git branch -M main 
        //git push -u origin main


        //6 - =====Caso NÂO queira criar um bench ====
        //git push origin master
    }
}
