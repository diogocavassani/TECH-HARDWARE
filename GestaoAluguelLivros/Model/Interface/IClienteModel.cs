using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public  interface IClienteModel
    {
         int Codigo { get; set; }
       string Nome { get; set; }
       string Sobrenome { get; set; }
        string Cpf { get; set; }
         string Sexo { get; set; }
        string ATivo { get; set; }
         DateTime DataNascimento { get; set; }
        string Rua { get; set; }
         string Bairro { get; set; }
        string Cidade { get; set; }
        string Numero { get; set; }
        string Telefone { get; set; }
        string UF { get; set; }
         string CEP { get; set; }

        int Inserir();
        bool Alterar();
        bool Apagar();
        IClienteModel ConsultarPorId(int ID);
        IList<IClienteModel> ConsultarTodos();
        IList<IClienteModel> ConsultarPorNome(string Nome);
        bool Validar(out string Alertas);
    }
}
