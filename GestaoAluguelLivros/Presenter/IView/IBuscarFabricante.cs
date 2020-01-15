using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
    public interface IBuscarFabricante
    {
        int ObterCOD_FABRICANTERegistroSelecionado();
        string ObterFABR_NOMERegistroSelecionado();
        void AtualizarGrade(object NovaLista);
        void FecharTelaComSucesso();
        void ExibirMensagemAviso(string Mensagem);
        void LimparCampoPesquisa();
        void AtualizarID(int ID, string Nome);
    }
}
