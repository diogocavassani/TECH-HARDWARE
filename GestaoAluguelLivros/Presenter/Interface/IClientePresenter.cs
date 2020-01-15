using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Interface
{
    public interface IClientePresenter
    {
        void Novo();
        void Alterar();
        void Salvar();
        void Apagar();
        void LimparTela();
        void LiberarBloquearComponentes(bool Liberar);
        void FocarNoPrimeiroCampo();
        void ConsultarPorId(int ID);
        void Buscar();
    }
}
