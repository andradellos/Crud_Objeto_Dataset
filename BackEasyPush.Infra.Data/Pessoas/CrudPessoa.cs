using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static BackEasyPush.Infra.Data.AcessoBase;
using static BackEasyPush.Infra.Data.Pessoas.ObjetoPessoa;

namespace BackEasyPush.Infra.Data.Pessoa
{
    //crud_Pessoa
    public class CrudPessoa
    {
        AcessoBase Base = new AcessoBase();

        public int Insert(Domain.Pessoa pessoa)
        {
            return Base.ExecuteProcedure("Pessoa_I", ParametrosUpDateInsert(pessoa)).RetornoBancoDados;
        }

        public int UpDate(Domain.Pessoa pessoa)
        {
            return Base.ExecuteProcedure("Pessoa_U", ParametrosUpDateInsert(pessoa)).RetornoBancoDados;
        }

        public int Delete(Domain.Pessoa pessoa)
        {
            return Base.ExecuteProcedure("Pessoa_D", ParametrosSelectDelete(pessoa)).RetornoBancoDados;
        }

        public Domain.Pessoa Select(Domain.Pessoa pessoa)
        {
            DataSet dt = Base.ExecuteProcedure("Pessoa_S", ParametrosSelectDelete(pessoa)).Dataset;
            return Base.CarregarObjeto<Domain.Pessoa>(dt);
        }

        public List<Domain.Pessoa> SelectGeral()
        {
            DataSet dt = Base.ExecuteProcedure("Pessoa_S", new List<ParametrosProcedure>()).Dataset;
            return Base.CarregarListaDeObjeto<Domain.Pessoa>(dt);
        }

        public List<ParametrosProcedure> ParametrosUpDateInsert(Domain.Pessoa pessoa)
        {
            List<ParametrosProcedure> ListaDeParametros = new List<ParametrosProcedure>();
            #region Parâmetros para a procedure
            ListaDeParametros = new List<ParametrosProcedure>();
            ListaDeParametros.Add(Base.ParametroProcedure("@IdPessoa", SqlDbType.Int, pessoa.IdPessoa.ToString()));
            ListaDeParametros.Add(Base.ParametroProcedure("@Nome", SqlDbType.VarChar, pessoa.Nome));
            ListaDeParametros.Add(Base.ParametroProcedure("@Nascimento", SqlDbType.Date, pessoa.Nascimento.ToString()));
            ListaDeParametros.Add(Base.ParametroProcedure("@Status", SqlDbType.VarChar, pessoa.Status));
            #endregion

            return ListaDeParametros;
        }

        public List<ParametrosProcedure> ParametrosSelectDelete(Domain.Pessoa pessoa)
        {
            List<ParametrosProcedure> ListaDeParametros = new List<ParametrosProcedure>();
            #region Parâmetros para a procedure           
            ListaDeParametros.Add(Base.ParametroProcedure("@IdPessoa", SqlDbType.Int, pessoa.IdPessoa.ToString()));
            #endregion

            return ListaDeParametros;
        }

    }
}
