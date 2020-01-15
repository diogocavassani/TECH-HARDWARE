using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Interface
{
     public interface IOrcamentoPresenter
    {
        void Novo();
        void Aletar();
        void Salvar();
        void Apagar();
        void LimparTela();
        void LiberarBloquearComponentes(bool Liberar);
        void FocarNoPrimeiroCampo();
        void ConsultarPorId(int id);
        void ObterClientes();
        void ObterFunciorio();
        void ObterProduto();
        void CalcularTotalProduto();
        void AdicionarProduto();
        void RemoverProduto();
        void Buscar();

    }
}
