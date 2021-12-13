using BackEasyPush.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static BackEasyPush.Infra.Data.AcessoBase;

namespace BackEasyPush.Infra.Data
{
    public class CrudContatos
    {
        AcessoBase Base = new AcessoBase();

        public int Insert(Contato contato)
        {
            return Base.ExecuteProcedure("Contatos_I", ParametrosInsert(contato)).RetornoBancoDados;
        }

        public int UpDate(Contato contato)
        {
            return Base.ExecuteProcedure("Contatos_U", ParametrosUpDate(contato)).RetornoBancoDados;
        }

        public int Delete(Contato contato)
        {
            return Base.ExecuteProcedure("Contatos_D", ParametrosSelectDelete(contato)).RetornoBancoDados;
        }

        public Contato Select(Contato contato)
        {
            DataSet dt = Base.ExecuteProcedure("Contatos_S", ParametrosSelectDelete(contato)).Dataset;
            return Base.CarregarObjeto<Contato>(dt);
        }

        public List<Contato> SelectGeral()
        {
            DataSet dt = Base.ExecuteProcedure("Contatos_S", new List<ParametrosProcedure>()).Dataset;
            return Base.CarregarListaDeObjeto<Contato>(dt);
        }


        public List<ParametrosProcedure> ParametrosUpDate(Contato contato)
        {
            List<ParametrosProcedure> ListaDeParametros = new List<ParametrosProcedure>();
            #region Parâmetros para a procedure
            ListaDeParametros = new List<ParametrosProcedure>();
            ListaDeParametros.Add(Base.ParametroProcedure("@IdContato", SqlDbType.Int, contato.IdContato.ToString())); 
            ListaDeParametros.Add(Base.ParametroProcedure("@IdPessoa", SqlDbType.Int, contato.IdPessoa.ToString()));
            ListaDeParametros.Add(Base.ParametroProcedure("@Numero", SqlDbType.VarChar, contato.Numero));
            ListaDeParametros.Add(Base.ParametroProcedure("@Status", SqlDbType.VarChar, contato.Status));
            ListaDeParametros.Add(Base.ParametroProcedure("@Tipo", SqlDbType.VarChar, contato.Tipo));
            #endregion

            return ListaDeParametros;
        }

        public List<ParametrosProcedure> ParametrosInsert(Contato contato)
        {
            List<ParametrosProcedure> ListaDeParametros = new List<ParametrosProcedure>();
            #region Parâmetros para a procedure
            ListaDeParametros = new List<ParametrosProcedure>();           
            ListaDeParametros.Add(Base.ParametroProcedure("@IdPessoa", SqlDbType.Int, contato.IdPessoa.ToString()));
            ListaDeParametros.Add(Base.ParametroProcedure("@Numero", SqlDbType.VarChar, contato.Numero));
            ListaDeParametros.Add(Base.ParametroProcedure("@Status", SqlDbType.VarChar, contato.Status));
            ListaDeParametros.Add(Base.ParametroProcedure("@Tipo", SqlDbType.VarChar, contato.Tipo));
            #endregion

            return ListaDeParametros;
        }

        public List<ParametrosProcedure> ParametrosSelectDelete(Contato contato)
        {
            List<ParametrosProcedure> ListaDeParametros = new List<ParametrosProcedure>();
            #region Parâmetros para a procedure           
            ListaDeParametros.Add(Base.ParametroProcedure("@IdContato", SqlDbType.Int, contato.IdContato.ToString()));
            #endregion

            return ListaDeParametros;
        }

    }
}
