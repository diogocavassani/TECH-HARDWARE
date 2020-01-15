using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IProdutosModel
    {
        int Codigo { get; set; }
        string Nome { get; set; }
        decimal ValorUnitario { get; set; }
        int Quantidade { get; set; }
        int codFabricante { get; set; }
        int codDistribuidora { get; set; }
        string Fabricante { get; set; }
        string Distribuidora { get; set; }
        int Inserir();
        bool Alterar();
        bool Apagar();
        IProdutosModel ConsultarPorId(int ID);
        IList<IProdutosModel> ConsultarTodos();
        IList<IProdutosModel> ConsultarPorNome(string Nome);
        IList<IProdutosModel> ObterFabricantes();
        IList<IProdutosModel> ObterDistribuidora();
        bool Validar(out string Alertas);
    }
}
