using System;
using System.Data;
using System.Data.SqlClient;

namespace AcessoBancoDados
{
    public class AcessoDadosSqlServer
    {
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        private SqlConnection CriarConexao()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=localhost;User Id=sa;Password=123456;Initial Catalog=BD_INTER;Integrated Security=SSPI";
            conn.Open();
            return conn;
        }

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        public int ExecutarManipulacao(CommandType commandType, string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                //return sqlCommand.ExecuteNonQuery();
                return Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha ao executar o comando no banco de dados.\r\nMensagem original: " + ex.Message);
            }
        }

        public object ExecutarConsultaScalar(CommandType commandType, string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha ao executar o comando no banco de dados.\r\nMensagem original: " + ex.Message);
            }
        }

        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha ao recuperar os dados do banco de dados.\r\nMensagem original: " + ex.Message);
            }
        }
    }
}