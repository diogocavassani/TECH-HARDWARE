using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IItemOrcamentoModel
    {
        int CodigoItemOrcamento { get; set; }
        int CodigoProduto { get; set; }
        int CodigoOrcamento { get; set; }
        int Valorproduto { get; set; }
        int Quantidade { get; set; }

        int inserir();
        bool Apagar();
        bool Alterar();

        IItemOrcamentoModel ConsultaPorID(int ID);

        IList<IItemOrcamentoModel> ConsultarTodos();
    }
}
