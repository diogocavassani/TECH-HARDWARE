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
    public class OrcamentoModel : IOrcamentoModel
    {
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public int CodigoFuncionario { get; set; }
        public string NomeFuncionario { get; set; }
        public IList<IItemOrcamentoModel> ListaProdutos { get; set; }

        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();
        public bool Alterar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_ORCAMENTO",Codigo);
            acessoDados.AdicionarParametros("@COD_CLIENTE",CodigoCliente);
            acessoDados.AdicionarParametros("@COD_FUNCIONARIO",CodigoFuncionario);

            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_ALTERAR_ORCAMENTO") > 0);
        }

        public bool Apagar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_ORCAMENTO",Codigo);
            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_EXCLUIR_ORCAMENTO") > 0);
        }

        public IList<IOrcamentoModel> ConsultarTodos()
        {
            acessoDados.LimparParametros();
            DataTable dataTable = acessoDados.ExecutarConsulta(CommandType.StoredProcedure,"SP_CONSULTAR_ORCAMENTOS");
            IList<IOrcamentoModel> listaOrcamentos = new List<IOrcamentoModel>();
            foreach (DataRow datarow in dataTable.Rows)
            {
                //verificar aqui se todas as colunas devem ser exibidas no gridview
                IOrcamentoModel orcamento = new OrcamentoModel();
                orcamento.Codigo = Convert.ToInt32(datarow["COD_ORCAMENTO"]);
                orcamento.CodigoCliente = Convert.ToInt32(datarow["COD_CLIENTE"]);
                orcamento.NomeCliente = Convert.ToString(datarow["CLI_NOME"]);
                orcamento.CodigoFuncionario = Convert.ToInt32(datarow["COD_FUNCIONARIO"]);
                orcamento.NomeFuncionario = Convert.ToString(datarow["FUNC_NOME"]);
                listaOrcamentos.Add(orcamento);
            }
            return listaOrcamentos;
        }

        public int Inserir()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_CLIENTE", CodigoCliente);
            acessoDados.AdicionarParametros("@COD_FUNCIONARIO", CodigoFuncionario);

            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_INSERIR_ORCAMENTO"));

        }

        public IOrcamentoModel ConsultarporID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
