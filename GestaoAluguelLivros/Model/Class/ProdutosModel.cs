using AcessoBancoDados;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Class
{
    public class ProdutosModel : IProdutosModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public int codFabricante { get; set; }
        public int codDistribuidora { get; set; }
        public string Fabricante { get; set; }
        public string Distribuidora { get; set; }

        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public bool Alterar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_PRODUTO", Codigo);
            acessoDados.AdicionarParametros("@PROD_NOME", Nome);
            acessoDados.AdicionarParametros("@PROD_VALOR", ValorUnitario);
            acessoDados.AdicionarParametros("@COD_FABRICANTE", codFabricante);
            acessoDados.AdicionarParametros("@COD_DISTRIBUIDORA", codDistribuidora);

            return acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_ALTERAR_PRODUTO") > 0;
        }

        public bool Apagar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_PRODUTO", Codigo);

            return acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_DELETAR_PRODUTO") > 0;
        }

        public IProdutosModel ConsultarPorId(int ID)
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@IdProduto", ID);

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_PRODUTO_POR_ID");

            IProdutosModel produtos = new ProdutosModel();
            produtos.Codigo = Convert.ToInt32(dataTable.Rows[0]["COD_PRODUTO"]);
            produtos.Nome = Convert.ToString(dataTable.Rows[0]["PROD_NOME"]);
            produtos.ValorUnitario = Convert.ToInt32(dataTable.Rows[0]["PROD_VALOR"]);
            produtos.Quantidade = Convert.ToInt32(dataTable.Rows[0]["EST_QUANTIDADE"]);
            produtos.Fabricante = Convert.ToString(dataTable.Rows[0]["FABR_NOME"]);
            produtos.Distribuidora = Convert.ToString(dataTable.Rows[0]["DIST_NOME"]);
            

            return produtos;
        }

        public IList<IProdutosModel> ConsultarPorNome(string Nome)
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@Nome", Nome);

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_PRODUTO_POR_NOME");

            IList<IProdutosModel> listaProdutos = new List<IProdutosModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IProdutosModel produtos = new ProdutosModel();
                produtos.Codigo = Convert.ToInt32(dataRow["COD_PRODUTO"]);
                produtos.Nome = Convert.ToString(dataRow["PROD_NOME"]);
                produtos.ValorUnitario = Convert.ToInt32(dataRow["PROD_VALOR"]);
                produtos.Quantidade = Convert.ToInt32(dataRow["EST_QUANTIDADE"]);
                produtos.Fabricante = Convert.ToString(dataRow["FABR_NOME"]);
                produtos.Distribuidora = Convert.ToString(dataRow["DIST_NOME"]);

                listaProdutos.Add(produtos);
            }
            return listaProdutos;
        }

        public IList<IProdutosModel> ConsultarTodos()
        {
            acessoDados.LimparParametros();

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_TODOS_PRODUTOS");

            IList<IProdutosModel> listaProdutos = new List<IProdutosModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IProdutosModel produtos = new ProdutosModel();
                produtos.Codigo = Convert.ToInt32(dataRow["COD_PRODUTO"]);
                produtos.Nome = Convert.ToString(dataRow["PROD_NOME"]);
                produtos.ValorUnitario = Convert.ToInt32(dataRow["PROD_VALOR"]);
                produtos.Quantidade = Convert.ToInt32(dataRow["EST_QUANTIDADE"]);
                produtos.Fabricante = Convert.ToString(dataRow["FABR_NOME"]);
                produtos.Distribuidora = Convert.ToString(dataRow["DIST_NOME"]);

                listaProdutos.Add(produtos);
            }
            return listaProdutos;
        }

        public IList<IProdutosModel> ObterFabricantes() {
            acessoDados.LimparParametros();

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_FABRICANTE");

            IList<IProdutosModel> listFabricante = new List<IProdutosModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IProdutosModel fabricante = new ProdutosModel();
                fabricante.codFabricante = Convert.ToInt32(dataRow["COD_FABRICANTE"]);
                fabricante.Fabricante = Convert.ToString(dataRow["FABR_NOME"]);

                listFabricante.Add(fabricante);
            }
            return listFabricante;
        }
        public IList<IProdutosModel> ObterDistribuidora()
        {
            acessoDados.LimparParametros();

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_DISTRIBUIDORA");

            IList<IProdutosModel> listDistribuidora = new List<IProdutosModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IProdutosModel distribuidora = new ProdutosModel();
                distribuidora.codDistribuidora = Convert.ToInt32(dataRow["COD_DISTRIBUIDORA"]);
                distribuidora.Distribuidora = Convert.ToString(dataRow["DIST_NOME"]);

                listDistribuidora.Add(distribuidora);
            }
            return listDistribuidora;
        }

        public int Inserir()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@PROD_NOME", Nome);
            acessoDados.AdicionarParametros("@PROD_VALOR", ValorUnitario);
            acessoDados.AdicionarParametros("@COD_FABRICANTE", codFabricante);
            acessoDados.AdicionarParametros("@COD_DISTRIBUIDORA", codDistribuidora);
            acessoDados.AdicionarParametros("@EST_QUANTIDADE", Quantidade);

            return acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_INSERIR_PRODUTO");
        }

        public bool Validar(out string Alertas)
        {
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                msg.Append("É necessário informar o nome do produto.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(ValorUnitario.ToString())) {
                msg.Append("É necessário informar o valor unitário.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Quantidade.ToString())) {
                msg.Append("É necessário informar a quantidade.");
                msg.AppendLine();
            }
            else if (Fabricante.ToString() == "Selecione") {
                msg.Append("É necessário informar o fabricante.");
                msg.AppendLine();
            }
            else if (Distribuidora.ToString() == "Selecione") {
                msg.Append("É necessário informar a distribuidora.");
                msg.AppendLine();
            }

            Alertas = msg.ToString();
            return (msg.Length == 0);
        }
    }
}
