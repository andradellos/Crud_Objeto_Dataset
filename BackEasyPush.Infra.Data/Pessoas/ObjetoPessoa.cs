using BackEasyPush.Domain;
using System.Collections.Generic;
using System.Data;
using static BackEasyPush.Domain.EmComum;
using static BackEasyPush.Infra.Data.AcessoBase;

namespace BackEasyPush.Infra.Data.Pessoas
{
    //A ideia dessa classe é criar os dados da tela inicial OnInit() no Angular por exemplo.
    //acessando uma vez apenas a base de daos cuidando da performance
    public class ObjetoPessoa
    {       
        Domain.Pessoa pessoa = new Domain.Pessoa();
        AcessoBase Base = new AcessoBase();

        /// <summary>
        /// Por default as propriedades não serão carregadas com dados. Necessário configurar alguma propriedade para trazer.
        /// Ex. CarregarDados.Pessoa = valor.Sim; ou CarregarDados.Geral();
        /// </summary>
        /// <param name="IdPessoa">Id da Pessoa</param>
        /// <returns></returns>
        public Domain.Pessoa Carregar(int IdPessoa)
        {
            DataSet dts = ConsultarBaseDeDados(IdPessoa);

            //Objeto principal deve ser sempre o primeiro a ser carregado a órdem das propriedades não importa.
            pessoa = Base.CarregarObjeto<Domain.Pessoa>(dts, "Pessoa", CarregarDados.Pessoa);
            pessoa.Contatos = Base.CarregarListaDeObjeto<Contato>(dts, "Contatos", CarregarDados.Contatos);
            pessoa.Enderecos = Base.CarregarListaDeObjeto<Endereco>(dts, "Endereco", CarregarDados.Enderecos);

            return pessoa;
        }

        private DataSet ConsultarBaseDeDados(int IdPessoa)
        {
            #region Parâmetros para a procedure
            List<ParametrosProcedure> ListaDeParametros = new List<ParametrosProcedure>();
            ListaDeParametros.Add(Base.ParametroProcedure("@IdPessoa", SqlDbType.Int, IdPessoa.ToString()));
            ListaDeParametros.Add(Base.ParametroProcedure("@CarregaEndereco", SqlDbType.VarChar, CarregarDados.Enderecos));
            ListaDeParametros.Add(Base.ParametroProcedure("@CarregaContatos", SqlDbType.VarChar, CarregarDados.Contatos));
            ListaDeParametros.Add(Base.ParametroProcedure("@CarregaPessoa", SqlDbType.VarChar, CarregarDados.Pessoa));
            #endregion

            return Base.ExecuteProcedure("ObjetoPessoa", ListaDeParametros).Dataset;
        }

        /// <summary>
        /// Por default as propriedades não serão carregadas com dados. Antes de chamar o método carregar, necessário configurar alguma propriedade para trazer.
        /// Ex. CarregarDados.Pessoa = valor.Sim; ou CarregarDados.Geral();
        /// </summary>
        public static class CarregarDados
        {
            public static string Pessoa { get; set; } = valor.Nao;
            public static string Enderecos { get; set; } = valor.Nao;
            public static string Contatos { get; set; } = valor.Nao;

            /// <summary>
            /// Configura para valor.Sim e Carregando dados de todas as propriedades do objeto em questão
            /// </summary>
            public static void Geral()
            {
                Pessoa = valor.Sim;
                Enderecos = valor.Sim;
                Contatos = valor.Sim;
            }
        }        
    }
}
