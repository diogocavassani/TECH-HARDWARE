using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Class
{
    public class ItemOrcamentoModel : IItemOrcamentoModel
    {
        public int CodigoItemOrcamento { get; set; } //int
        public int CodigoProduto { get; set; } // produto
        public int CodigoOrcamento { get; set; } //orçamento
        public int Valorproduto { get; set; } // não precisa
        public int Quantidade { get; set; } //nao precisa

        public bool Alterar()
        {
            throw new NotImplementedException();
        }

        public bool Apagar()
        {
            throw new NotImplementedException();
        }

        public IItemOrcamentoModel ConsultaPorID(int ID)
        {
            throw new NotImplementedException();
        }

        public IList<IItemOrcamentoModel> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public int inserir()
        {
            throw new NotImplementedException();
        }
    }
}
