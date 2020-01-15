using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IOrcamentoModel
    {
        int Codigo { get; set; }
        int CodigoCliente { get; set; }
        string NomeCliente { get; set; }
        int CodigoFuncionario { get; set; }
        string NomeFuncionario { get; set; }
        IList<IItemOrcamentoModel> ListaProdutos { get; set; }
        int Inserir();
        bool Alterar();
        bool Apagar();

        IOrcamentoModel ConsultarporID(int Id);
        IList<IOrcamentoModel> ConsultarTodos();
    }
}
