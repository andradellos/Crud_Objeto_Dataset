using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static BackEasyPush.Domain.EmComum;

namespace BackEasyPush.Infra.Data
{
    public class AcessoBase
    {
        public RetornoAcessoBase ExecuteProcedure(string NomeDaProcedure, List<ParametrosProcedure> ListaDeParametros)
        {
            String stringConection = "Data Source=EMANUEL\\SQLEXPRESS;Initial Catalog=BdEasyPush;Integrated Security=True";
            RetornoAcessoBase retornoAcessoBase = new RetornoAcessoBase();

            DataSet dt = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = stringConection;

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = NomeDaProcedure;

            foreach (ParametrosProcedure item in ListaDeParametros)
            {
                command.Parameters.Add(item.NameParemeter, item.Type).Value = item.Value;
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            retornoAcessoBase.Dataset = dt;
            retornoAcessoBase.RetornoBancoDados = adapter.Fill(dt);

            return retornoAcessoBase;
        }

        public class ParametrosProcedure
        {
            public string NameParemeter { get; set; }
            public SqlDbType Type { get; set; }
            public string Value { get; set; }
        }

        public static List<T> ConverterParaLista<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();

            var type = typeof(T).Name;
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception)
                        { }
                    }
                }
                return objT;
            }).ToList();
        }

        public ParametrosProcedure ParametroProcedure(string NameParemeter, SqlDbType type, string value)
        {
            return new ParametrosProcedure { NameParemeter = NameParemeter, Type = type, Value = value };
        }


        public T CarregarObjeto<T>(DataSet dts, string ObjetoPrincipal) where T : new()
        {
            T classe = new T();

            foreach (DataTable table in dts.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    string tabela = table.Rows[0]["tabela"].ToString().Trim();

                    if (tabela == ObjetoPrincipal)
                    {
                        classe = ConverterParaLista<T>(table).FirstOrDefault();
                    }
                }
            }
            return classe;
        }

        public T CarregarObjeto<T>(DataSet dts) where T : new()
        {
            T classe = new T();

            foreach (DataTable table in dts.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    classe = ConverterParaLista<T>(table).FirstOrDefault();
                }
            }
            return classe;
        }


        public List<T> CarregarListaDeObjeto<T>(DataSet dts, string ObjetoPrincipal) where T : new()
        {
            List<T> classe = new List<T>();

            foreach (DataTable table in dts.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    string tabela = table.Rows[0]["tabela"].ToString().Trim();

                    if (tabela == ObjetoPrincipal)
                    {
                        classe = ConverterParaLista<T>(table);
                    }
                }
            }
            return classe;
        }


        public List<T> CarregarListaDeObjeto<T>(DataSet dts, string ObjetoPrincipal, string carregaDados) where T : new()
        {
            List<T> classe = new List<T>();

            foreach (DataTable table in dts.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    string tabela = table.Rows[0]["tabela"].ToString().Trim();

                    if (tabela == ObjetoPrincipal && carregaDados == valor.Sim)
                    {
                        classe = ConverterParaLista<T>(table);
                    }
                }
            }
            return classe;
        }


        public List<T> CarregarListaDeObjeto<T>(DataSet dts) where T : new()
        {
            List<T> classe = new List<T>();

            foreach (DataTable table in dts.Tables)
            {
                if (table.Rows.Count > 0)
                {
                    classe = ConverterParaLista<T>(table);
                }
            }
            return classe;
        }























        public void consulta1(string NomeDaProcedure, List<ParametrosProcedure> ListaDeParametros)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;


            try
            {
                conn = new SqlConnection("Data Source=EMANUEL\\SQLEXPRESS;Initial Catalog=BdEasyPush;Integrated Security=True");
                conn.Open();


                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = NomeDaProcedure;


                foreach (ParametrosProcedure item in ListaDeParametros)
                {
                    command.Parameters.Add(item.NameParemeter, item.Type).Value = item.Value;
                }

                // Executando o commando e obtendo o resultado
                reader = command.ExecuteReader();

                // Exibindo os registros
                while (reader.Read())
                {
                    Console.WriteLine("{0}, {1}",
                        reader["Rua"],
                        reader["Uf"]);
                }
            }
            finally
            {
                // Fecha o datareader
                if (reader != null)
                {
                    reader.Close();
                }

                // Fecha a conexão
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
    public class RetornoAcessoBase
    {
        public DataSet Dataset { get; set; }
        public int RetornoBancoDados { get; set; }
    }
}
