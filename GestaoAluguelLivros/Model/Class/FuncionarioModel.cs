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
    public class FuncionarioModel : IFuncionarioModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool Fun_Ativo { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string Telefone { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        public bool Alterar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@COD_FUNCIONARIO", Codigo);
            acessoDados.AdicionarParametros("@FUNC_NOME", Nome);
            acessoDados.AdicionarParametros("@FUNC_SOBRENOME", Sobrenome);
            acessoDados.AdicionarParametros("@END_RUA", Rua);
            acessoDados.AdicionarParametros("@END_BAIRRO", Bairro);
            acessoDados.AdicionarParametros("@END_CIDADE", Cidade);
            acessoDados.AdicionarParametros("@END_NUMERO", Numero);
            acessoDados.AdicionarParametros("@END_CEP", CEP);
            acessoDados.AdicionarParametros("@END_UF", UF);
            acessoDados.AdicionarParametros("@TEL_NUMERO", Telefone);

            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_ALTERAR_FUNCIONARIOS")>0);
        }

        public bool Apagar()
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@ID", Codigo);


            return (acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_DELETAR_FUNCIONARIO") > 0);
        }

        public IFuncionarioModel ConsultarPorId(int ID)
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@ID", ID);

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_FUNCIONARIO_POR_ID");

            IFuncionarioModel funcionario = new FuncionarioModel();
            funcionario.Codigo = Convert.ToInt32(dataTable.Rows[0]["COD_FUNCIONARIO"]);
            funcionario.Nome = Convert.ToString(dataTable.Rows[0]["FUNC_NOME"]);
            funcionario.Sobrenome = Convert.ToString(dataTable.Rows[0]["FUNC_SOBRENOME"]);
            funcionario.Rua = Convert.ToString(dataTable.Rows[0]["END_RUA"]);
            funcionario.Bairro = Convert.ToString(dataTable.Rows[0]["END_BAIRRO"]);
            funcionario.Cidade = Convert.ToString(dataTable.Rows[0]["END_CIDADE"]);
            funcionario.Numero = Convert.ToString(dataTable.Rows[0]["END_NUMERO"]);
            funcionario.CEP = Convert.ToString(dataTable.Rows[0]["END_CEP"]);
            funcionario.UF = Convert.ToString(dataTable.Rows[0]["END_UF"]);
            funcionario.Telefone = Convert.ToString(dataTable.Rows[0]["TEL_NUMERO"]);


            return funcionario;
        }

        public IList<IFuncionarioModel> ConsultarPorNome(string Nome)
        {
            acessoDados.LimparParametros();
            acessoDados.AdicionarParametros("@NOME", Nome);

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_FUNCIONARIO_POR_NOME");

            IList<IFuncionarioModel> listaFuncionario = new List<IFuncionarioModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IFuncionarioModel funcionario = new FuncionarioModel();
                funcionario.Codigo = Convert.ToInt32(dataRow["COD_FUNCIONARIO"]);
                funcionario.Nome = Convert.ToString(dataRow["FUNC_NOME"]);
                funcionario.Sobrenome = Convert.ToString(dataRow["FUNC_SOBRENOME"]);
                funcionario.Rua = Convert.ToString(dataRow["END_RUA"]);
                funcionario.Bairro = Convert.ToString(dataRow["END_BAIRRO"]);
                funcionario.Cidade = Convert.ToString(dataRow["END_CIDADE"]);
                funcionario.Numero = Convert.ToString(dataRow["END_NUMERO"]);
                funcionario.CEP = Convert.ToString(dataRow["END_CEP"]);
                funcionario.UF = Convert.ToString(dataRow["END_UF"]);
                funcionario.Telefone = Convert.ToString(dataRow["TEL_NUMERO"]);

                listaFuncionario.Add(funcionario);
            }
            return listaFuncionario;
        }

        public IList<IFuncionarioModel> ConsultarTodos()
        {
            acessoDados.LimparParametros();
           

            DataTable dataTable =
                acessoDados.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_TODOS_FUNCIONARIOS");

            IList<IFuncionarioModel> listaFuncionario = new List<IFuncionarioModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IFuncionarioModel funcionario = new FuncionarioModel();
                funcionario.Codigo = Convert.ToInt32(dataRow["COD_FUNCIONARIO"]);
                funcionario.Nome = Convert.ToString(dataRow["FUNC_NOME"]);
                funcionario.Sobrenome = Convert.ToString(dataRow["FUNC_SOBRENOME"]);
                funcionario.Rua = Convert.ToString(dataRow["END_RUA"]);
                funcionario.Bairro = Convert.ToString(dataRow["END_BAIRRO"]);
                funcionario.Cidade = Convert.ToString(dataRow["END_CIDADE"]);
                funcionario.Numero = Convert.ToString(dataRow["END_NUMERO"]);
                funcionario.CEP = Convert.ToString(dataRow["END_CEP"]);
                funcionario.UF = Convert.ToString(dataRow["END_UF"]);
                funcionario.Telefone = Convert.ToString(dataRow["TEL_NUMERO"]);

                listaFuncionario.Add(funcionario);
            }
            return listaFuncionario;
        }

        public int Inserir()
        {
            acessoDados.LimparParametros();
           
            acessoDados.AdicionarParametros("@FUNC_NOME", Nome);
            acessoDados.AdicionarParametros("@FUNC_SOBRENOME", Sobrenome);
            acessoDados.AdicionarParametros("@END_RUA", Rua);
            acessoDados.AdicionarParametros("@END_BAIRRO", Bairro);
            acessoDados.AdicionarParametros("@END_CIDADE", Cidade);
            acessoDados.AdicionarParametros("@END_NUMERO", Numero);
            acessoDados.AdicionarParametros("@END_CEP", CEP);
            acessoDados.AdicionarParametros("@END_UF", UF);
            acessoDados.AdicionarParametros("@TEL_NUMERO", Telefone);



            return acessoDados.ExecutarManipulacao(CommandType.StoredProcedure, "SP_INSERIR_FUNCIONARIOS");
        }

        public bool Validar(out string Alertas)
        {
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                msg.Append("É necessário informar o nome do Funcionario.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Sobrenome.Trim()))
            {
                msg.Append("É necessário informar o sobrenome do Funcionario.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Rua.Trim()))
            {
                msg.Append("É necessário informar a rua do Funcionario.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Cidade.Trim()))
            {
                msg.Append("É necessário informar a cidade do Funcionario.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Bairro.Trim()))
            {
                msg.Append("É necessário informar o Bairro do Funcionario.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(CEP.Trim()))
            {
                msg.Append("É necessário informar o CEP do Funcionario.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(UF.Trim()))
            {
                msg.Append("É necessário informar o UF do Funcionario.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Telefone.Trim()))
            {
                msg.Append("É necessário informar o Telefone do Funcionario.");
                msg.AppendLine();
            }

            Alertas = msg.ToString();
            return (msg.Length == 0);
        }
    }
}
