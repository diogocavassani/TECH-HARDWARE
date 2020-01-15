
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AcessoBancoDados;
using Model.Interface;

namespace Model.Class
{
    public class FabricanteModel : IFabricanteModel
    {
        public int COD_FABRICANTE { get; set; }
        public string FABR_NOME { get; set; }


        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public int Inserir()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@FABR_NOME", FABR_NOME);

            return acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "[dbo].[SP_INSERIR_FABRICANTE]");
        }

        public bool Alterar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_FABRICANTE", COD_FABRICANTE);
            acessoDados.AdicionarParametros("@FABR_NOME", FABR_NOME);


            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "[dbo].[SP_ALTERAR_FABRICANTE]") > 0);
        }

        public bool Apagar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_FABRICANTE", COD_FABRICANTE);

            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "[dbo].[SP_DELETAR_FABRICANTE]") > 0);
        }

        public IFabricanteModel ConsultarPorId(string ID)
        {
            acessoDados.LimparParametros();
            int COD_FABRICANTE = int.Parse(ID);
            acessoDados.AdicionarParametros("@COD_FABRICANTE", COD_FABRICANTE);

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "[dbo].[SP_CONSULTARID_FABRICANTE]");

            IFabricanteModel fabricante = new FabricanteModel();
            fabricante.COD_FABRICANTE = Convert.ToInt32(dataTable.Rows[0]["COD_FABRICANTE"]);
            fabricante.FABR_NOME = Convert.ToString(dataTable.Rows[0]["FABR_NOME"]);



            return fabricante;
        }

        public IList<IFabricanteModel> ConsultarPorNome(string Nome)
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@FABR_NOME", Nome);

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "[dbo].[SP_CONSULTARNOME_FABRICANTE]");

            IList<IFabricanteModel> listaFabricante = new List<IFabricanteModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IFabricanteModel fabricante = new FabricanteModel();
                fabricante.COD_FABRICANTE = Convert.ToInt32(dataTable.Rows[0]["COD_FABRICANTE"]);
                fabricante.FABR_NOME = Convert.ToString(dataTable.Rows[0]["FABR_NOME"]);



                listaFabricante.Add(fabricante);
            }
            return listaFabricante;
        }
        public IList<IFabricanteModel> ConsultarTodos()
        {
            acessoDados.LimparParametros();

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "[dbo].[SP_CONSULTAR_FABRICANTE]");

            IList<IFabricanteModel> listaFabricante = new List<IFabricanteModel>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                IFabricanteModel fabricante = new FabricanteModel();
                fabricante.COD_FABRICANTE = Convert.ToInt32(dataTable.Rows[0]["COD_FABRICANTE"]);
                fabricante.FABR_NOME = Convert.ToString(dataTable.Rows[0]["FABR_NOME"]);



                listaFabricante.Add(fabricante);
            }
            return listaFabricante;
        }

        public bool Validar(out string Alertas)
        {
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrEmpty(COD_FABRICANTE.ToString().Trim()))
            {
                msg.Append("É necessário informar o nome do fabricante.");
                msg.AppendLine();
            }

            Alertas = msg.ToString();
            return (msg.Length == 0);
        }

    }
}