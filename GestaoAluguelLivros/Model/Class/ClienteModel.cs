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
    public class ClienteModel : IClienteModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string ATivo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string Telefone { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        AcessoDadosSqlServer Banco = new AcessoDadosSqlServer();
        public bool Alterar()
        {
            Banco.LimparParametros();
            Banco.AdicionarParametros("@CLI_NOME", Nome);
            Banco.AdicionarParametros("@CLI_SOBRENOME", Sobrenome);
            Banco.AdicionarParametros("@CLI_CPF", Cpf);
            Banco.AdicionarParametros("@CLI_DTNASC", DataNascimento);
            Banco.AdicionarParametros("@CLI_SEXO", Sexo);
            Banco.AdicionarParametros("@END_RUA", Rua);
            Banco.AdicionarParametros("@END_BAIRRO", Bairro);
            Banco.AdicionarParametros("@END_CIDADE", Cidade);
            Banco.AdicionarParametros("@END_NUMERO", Numero);
            Banco.AdicionarParametros("@END_CEP", CEP);
            Banco.AdicionarParametros("@END_UF", UF);
            Banco.AdicionarParametros("@Tel_Telefone", Telefone);

            return (Banco.ExecutarManipulacao(CommandType.StoredProcedure, "SP_ALTERAR_CLIENTES") > 0);
        }

        public bool Apagar()
        {
            Banco.LimparParametros();
            Banco.AdicionarParametros("@Cod_Cliente", Codigo);
            return (Banco.ExecutarManipulacao(CommandType.StoredProcedure, "SP_DELETAR_CLIENTES") > 0);
        }

        public IClienteModel ConsultarPorId(int ID)
        {
            Banco.LimparParametros();
            Banco.AdicionarParametros("@COD_CLIENTE", ID);
            DataTable dataTable =
                Banco.ExecutarConsulta(CommandType.StoredProcedure,
                "SP_CONSULTAR_CODIGO_CLIENTES");

            IClienteModel cliente = new ClienteModel();
            cliente.Codigo = Convert.ToInt32(dataTable.Rows[0]["COD_CLIENTE"]);
            cliente.Nome = Convert.ToString(dataTable.Rows[0]["CLI_NOME"]);
            cliente.Sobrenome = Convert.ToString(dataTable.Rows[0]["CLI_SOBRENOME"]);
            cliente.Cpf = Convert.ToString(dataTable.Rows[0]["CLI_SOBRENOME"]);
            cliente.Sexo = Convert.ToString(dataTable.Rows[0]["CLI_SEXO"]);
            cliente.DataNascimento = Convert.ToDateTime(dataTable.Rows[0]["CLI_DTNASC"]);

            
            cliente.Telefone= Convert.ToString(dataTable.Rows[0]["TEL_NUMERO"]);
            
            cliente.Rua = Convert.ToString(dataTable.Rows[0]["END_RUA"]);
            cliente.Bairro = Convert.ToString(dataTable.Rows[0]["END_BAIRRO"]);
            cliente.Cidade = Convert.ToString(dataTable.Rows[0]["END_CIDADE"]);
            cliente.Numero = Convert.ToString(dataTable.Rows[0]["END_NUMERO"]);
            cliente.CEP = Convert.ToString(dataTable.Rows[0]["END_CEP"]);
            cliente.UF = Convert.ToString(dataTable.Rows[0]["END_UF"]);

            return cliente;
        }

        public IList<IClienteModel> ConsultarPorNome(string Nome)
        {
            Banco.LimparParametros();
            Banco.AdicionarParametros("@Nome", Nome);
            DataTable dataTable =
            Banco.ExecutarConsulta(CommandType.Text,
                "SELECT * from dbo.udf_ClienteInformacoes ('" + Nome + "') ");
            IList<IClienteModel> listaCliente = new List<IClienteModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IClienteModel cliente = new ClienteModel();
                 cliente.Codigo = Convert.ToInt32(dataRow["COD_CLIENTE"]);
                cliente.Nome = Convert.ToString(dataRow["CLI_NOME"]);
                cliente.Sobrenome = Convert.ToString(dataRow["CLI_SOBRENOME"]);
                cliente.Cpf = Convert.ToString(dataRow["CLI_SOBRENOME"]);
                cliente.Sexo = Convert.ToString(dataRow["CLI_CPF"]);
               // cliente.DataNascimento = Convert.ToDateTime(dataRow["CLI_DTNASC"]);
                
                cliente.Telefone= Convert.ToString(dataRow["TEL_NUMERO"]);
                
                cliente.Rua = Convert.ToString(dataRow["END_RUA"]);
                cliente.Bairro = Convert.ToString(dataRow["END_BAIRRO"]);
                cliente.Cidade = Convert.ToString(dataRow["END_CIDADE"]);
                cliente.Numero = Convert.ToString(dataRow["END_NUMERO"]);
                cliente.CEP= Convert.ToString(dataRow["END_CEP"]);
                cliente.UF = Convert.ToString(dataRow["END_UF"]);

                listaCliente.Add(cliente);
            }
            return listaCliente;
        }

        public IList<IClienteModel> ConsultarTodos()
        {
            Banco.LimparParametros();
            DataTable dataTable =
                 Banco.ExecutarConsulta(CommandType.StoredProcedure,
                 "SP_CONSULTAR_CLIENTES");
            IList<IClienteModel> listaCliente = new List<IClienteModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                IClienteModel cliente = new ClienteModel();


                cliente.Codigo = Convert.ToInt32(dataRow["COD_CLIENTE"]);
                cliente.Nome = Convert.ToString(dataRow["CLI_NOME"]);
                cliente.Sobrenome = Convert.ToString(dataRow["CLI_SOBRENOME"]);
                cliente.Cpf = Convert.ToString(dataRow["CLI_CPF"]);
                cliente.DataNascimento = Convert.ToDateTime(dataRow["CLI_DTNASC"]);
                cliente.Sexo = Convert.ToString(dataRow["CLI_SEXO"]);
               // cliente.Aitvo = Convert.ToString(dataRow["CLI_ATIVO"]);
                
                cliente.Telefone = Convert.ToString(dataRow["TEL_NUMERO"]);
                
                cliente.Rua = Convert.ToString(dataRow["END_RUA"]);
                cliente.Bairro = Convert.ToString(dataRow["END_BAIRRO"]);
                cliente.Cidade = Convert.ToString(dataRow["END_CIDADE"]);
                cliente.Numero = Convert.ToString(dataRow["END_NUMERO"]);
                cliente.CEP= Convert.ToString(dataRow["END_CEP"]);
                cliente.UF = Convert.ToString(dataRow["END_UF"]);


                listaCliente.Add(cliente);
            }
            return listaCliente;
        }

        public int Inserir()
        {
            Banco.LimparParametros();
            Banco.AdicionarParametros("@CLI_NOME", Nome);
            Banco.AdicionarParametros("@CLI_SOBRENOME", Sobrenome);
            Banco.AdicionarParametros("@CLI_CPF", Cpf);
            Banco.AdicionarParametros("@CLI_DTNASC", DataNascimento);
            Banco.AdicionarParametros("@CLI_SEXO", Sexo);
            Banco.AdicionarParametros("@END_RUA", Rua);
            Banco.AdicionarParametros("@END_BAIRRO", Bairro);
            Banco.AdicionarParametros("@END_CIDADE", Cidade);
            Banco.AdicionarParametros("@END_NUMERO", Numero);
            Banco.AdicionarParametros("@END_CEP", CEP);
            Banco.AdicionarParametros("@END_UF", UF);
            Banco.AdicionarParametros("@Tel_Telefone", Numero);

            return Banco.ExecutarManipulacao(CommandType.StoredProcedure, "SP_INSERIR_CLIENTES_ENDERECO_TELEFONE");
        }

        public bool Validar(out string Alertas)
        {
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                msg.Append("Insira o Nome do Cliente.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Sobrenome.Trim()))
            {
                msg.Append("Insira o Sobrenome do Cliente.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Cpf.Trim()))
            {
                msg.Append("Insira o CPF do Cliente.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Telefone.Trim()))
            {
                msg.Append("Insira o Numero de Telefone do Cliente.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Rua.Trim()))
            {
                msg.Append("Insira o Logradouro do Cliente.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Numero.Trim()))
            {
                msg.Append("Insira o Numero do Cliente.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(Bairro.Trim()))
            {
                msg.Append("Insira o Bairro do Cliente.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(UF.Trim()))
            {
                msg.Append("Insira a UF do Cliente.");
                msg.AppendLine();
            }
            else if (string.IsNullOrEmpty(CEP.Trim()))
            {
                msg.Append("Insira o Cep do Cliente.");
                msg.AppendLine();
            }
            Alertas = msg.ToString();
            return (msg.Length == 0);
        }
    }
}