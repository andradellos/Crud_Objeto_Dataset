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
            pessoa = Base.CarregarObjeto<Domain.Pessoa>(dts, "Pessoa");
            pessoa.Contatos = Base.CarregarListaDeObjeto<Contato>(dts, "Contatos");
            pessoa.Enderecos = Base.CarregarListaDeObjeto<Endereco>(dts, "Endereco");

            return pessoa;
        }

        private DataSet ConsultarBaseDeDados(int IdPessoa)
        {
            #region Parâmetros para a procedure
            List<ParametrosProcedure> ListaDeParametros = new List<ParametrosProcedure>();

            // Caso não queira que traga dados de alguma tabela é só:
            // Não adicionar o parâmetro da proceure.
            // E se adicionar passe o value igual a valor.Nao.
            ListaDeParametros.Add(Base.ParametroProcedure("@IdPessoa", SqlDbType.Int, IdPessoa.ToString()));
            ListaDeParametros.Add(Base.ParametroProcedure("@CarregaEndereco", SqlDbType.VarChar, valor.Sim));
            ListaDeParametros.Add(Base.ParametroProcedure("@CarregaContatos", SqlDbType.VarChar, valor.Sim));
            ListaDeParametros.Add(Base.ParametroProcedure("@CarregaPessoa", SqlDbType.VarChar, valor.Sim));
            #endregion

            //Aprocedure é inteligente para trazer as tabelas de acordo com o parâmetro "@Carrega..." for Sim ou Não.
           
            return Base.ExecuteProcedure("ObjetoPessoa", ListaDeParametros).Dataset;
        }
    }
}
