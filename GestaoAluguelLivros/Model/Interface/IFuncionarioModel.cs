using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IFuncionarioModel
    {
         int Codigo { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }
         bool Fun_Ativo { get; set; }
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
        IFuncionarioModel ConsultarPorId(int ID);
        IList<IFuncionarioModel> ConsultarTodos();
        IList<IFuncionarioModel> ConsultarPorNome(string Nome);
        bool Validar(out string Alertas);
    }
}
