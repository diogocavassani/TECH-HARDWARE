
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AcessoBancoDados;
using Model.Interface;

namespace Model.Class
{
    public class DistribuidoraModel : IDistribuidoraModel
    {
        public int COD_DISTRIBUIDORA { get; set; }
        public string DIST_NOME { get; set; }
        public string DIST_CNPJ { get; set; }
        public string END_RUA { get; set; }
        public string END_BAIRRO { get; set; }
        public string END_CIDADE { get; set; }
        public string END_NUMERO { get; set; }
        public string END_CEP { get; set; }
        public string END_UF { get; set; }
        public string TEL_NUMERO { get; set; }

        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@DIST_NOME", DIST_NOME);
            acessoDados.AdicionarParametros("@DIST_CNPJ", DIST_CNPJ);
            acessoDados.AdicionarParametros("@END_RUA", END_RUA);
            acessoDados.AdicionarParametros("@END_BAIRRO", END_BAIRRO);
            acessoDados.AdicionarParametros("@END_CIDADE", END_CIDADE);
            acessoDados.AdicionarParametros("@END_NUMERO", END_NUMERO);
            acessoDados.AdicionarParametros("@END_CEP", END_CEP);
            acessoDados.AdicionarParametros("@END_UF", END_UF);
            acessoDados.AdicionarParametros("@TEL_NUMERO", TEL_NUMERO);


            return acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_INSERIR_DISTRIBUIDORA");
        }

        public bool Alterar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_DISTRIBUIDORA", COD_DISTRIBUIDORA);
            acessoDados.AdicionarParametros("@DIST_NOME", DIST_NOME);
            acessoDados.AdicionarParametros("@DIST_CNPJ", DIST_CNPJ);
            acessoDados.AdicionarParametros("@END_RUA", END_RUA);
            acessoDados.AdicionarParametros("@END_BAIRRO", END_BAIRRO);
            acessoDados.AdicionarParametros("@END_CIDADE", END_CIDADE);
            acessoDados.AdicionarParametros("@END_NUMERO", END_NUMERO);
            acessoDados.AdicionarParametros("@END_CEP", END_CEP);
            acessoDados.AdicionarParametros("@END_UF", END_UF);
            acessoDados.AdicionarParametros("@TEL_NUMERO", TEL_NUMERO);

            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "[dbo].[SP_ALTERAR_DISTRIBUIDORA   ]") > 0);
        }

        public bool Apagar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_DISTRIBUIDORA", COD_DISTRIBUIDORA);

            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "[dbo].[SP_DELETAR_DISTRIBUIDORA]") > 0);
        }

        public IDistribuidoraModel ConsultarPorId(string ID)
        {
            acessoDados.LimparParametros();
            int COD_DISTRIBUIDORA = int.Parse(ID);
            acessoDados.AdicionarParametros("@COD_DISTRIBUIDORA", COD_DISTRIBUIDORA);

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "[dbo].[SP_CONSULTARID_DISTRIBUIDORA]");

            IDistribuidoraModel distribuidora = new DistribuidoraModel();
            distribuidora.COD_DISTRIBUIDORA = Convert.ToInt32(dataTable.Rows[0]["COD_DISTRIBUIDORA"]);
            distribuidora.DIST_NOME = Convert.ToString(dataTable.Rows[0]["DIST_NOME"]);
            distribuidora.DIST_CNPJ = Convert.ToString(dataTable.Rows[0]["DIST_CNPJ"]);
            distribuidora.END_RUA = Convert.ToString(dataTable.Rows[0]["END_RUA"]);
            distribuidora.END_BAIRRO = Convert.ToString(dataTable.Rows[0]["END_BAIRRO"]);
            distribuidora.END_CIDADE = Convert.ToString(dataTable.Rows[0]["END_CIDADE"]);
            distribuidora.END_NUMERO = Convert.ToString(dataTable.Rows[0]["END_NUMERO"]);
            distribuidora.END_CEP = Convert.ToString(dataTable.Rows[0]["END_CEP"]);
            distribuidora.END_UF = Convert.ToString(dataTable.Rows[0]["END_UF"]);
            distribuidora.TEL_NUMERO = Convert.ToString(dataTable.Rows[0]["TEL_NUMERO"]);


            return distribuidora;
        }

        public IList<IDistribuidoraModel> ConsultarPorNome(string Nome)
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@DIST_NOME", Nome);

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "[dbo].[SP_CONSULTARNOME_DISTRIBUIDORA]");

            IList<IDistribuidoraModel> listaDistribuidora = new List<IDistribuidoraModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IDistribuidoraModel distribuidora = new DistribuidoraModel();
                distribuidora.COD_DISTRIBUIDORA = Convert.ToInt32(dataTable.Rows[0]["COD_DISTRIBUIDORA"]);
                distribuidora.DIST_NOME = Convert.ToString(dataTable.Rows[0]["DIST_NOME"]);
                distribuidora.DIST_CNPJ = Convert.ToString(dataTable.Rows[0]["DIST_CNPJ"]);
                distribuidora.END_RUA = Convert.ToString(dataTable.Rows[0]["END_RUA"]);
                distribuidora.END_BAIRRO = Convert.ToString(dataTable.Rows[0]["END_BAIRRO"]);
                distribuidora.END_CIDADE = Convert.ToString(dataTable.Rows[0]["END_CIDADE"]);
                distribuidora.END_NUMERO = Convert.ToString(dataTable.Rows[0]["END_NUMERO"]);
                distribuidora.END_CEP = Convert.ToString(dataTable.Rows[0]["END_CEP"]);
                distribuidora.END_UF = Convert.ToString(dataTable.Rows[0]["END_UF"]);
                distribuidora.TEL_NUMERO = Convert.ToString(dataTable.Rows[0]["TEL_NUMERO"]);


                listaDistribuidora.Add(distribuidora);
            }
            return listaDistribuidora;
        }
        public IList<IDistribuidoraModel> ConsultarTodos()
        {
            acessoDados.LimparParametros();

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "[dbo].[SP_CONSULTARTODOS_DISTRIBUIDORA]");

            IList<IDistribuidoraModel> listaDistribuidora = new List<IDistribuidoraModel>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                IDistribuidoraModel distribuidora = new DistribuidoraModel();
                distribuidora.COD_DISTRIBUIDORA = Convert.ToInt32(dataTable.Rows[0]["COD_DISTRIBUIDORA"]);
                distribuidora.DIST_NOME = Convert.ToString(dataTable.Rows[0]["DIST_NOME"]);
                distribuidora.DIST_CNPJ = Convert.ToString(dataTable.Rows[0]["DIST_CNPJ"]);
                distribuidora.END_RUA = Convert.ToString(dataTable.Rows[0]["END_RUA"]);
                distribuidora.END_BAIRRO = Convert.ToString(dataTable.Rows[0]["END_BAIRRO"]);
                distribuidora.END_CIDADE = Convert.ToString(dataTable.Rows[0]["END_CIDADE"]);
                distribuidora.END_NUMERO = Convert.ToString(dataTable.Rows[0]["END_NUMERO"]);
                distribuidora.END_CEP = Convert.ToString(dataTable.Rows[0]["END_CEP"]);
                distribuidora.END_UF = Convert.ToString(dataTable.Rows[0]["END_UF"]);
                distribuidora.TEL_NUMERO = Convert.ToString(dataTable.Rows[0]["TEL_NUMERO"]);


                listaDistribuidora.Add(distribuidora);
            }
            return listaDistribuidora;
        }

        public bool Validar(out string Alertas)
        {
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrEmpty(COD_DISTRIBUIDORA.ToString().Trim()))
            {
                msg.Append("É necessário informar o nome da distribuidora.");
                msg.AppendLine();
            }

            Alertas = msg.ToString();
            return (msg.Length == 0);
        }

    }
}