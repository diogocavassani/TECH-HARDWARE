using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Interface
{
   public interface IClienteBuscaPresenter
    {
        void Pesquisar(string Texto = null);
        void SelecionarRegistro();
    }
}
