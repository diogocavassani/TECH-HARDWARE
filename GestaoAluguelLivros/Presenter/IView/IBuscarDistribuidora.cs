using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
    public interface IBuscarDistribuidora
    {
        int ObterCOD_DISTRIBUIDORARegistroSelecionado();
        string ObterDIST_NOMERegistroSelecionado();
        string ObterDIST_CNPJRegistroSelecionado();
        string ObterEND_RUARegistroSelecionado();
        string ObterEND_BAIRRORegistroSelecionado();
        string ObterEND_CIDADERegistroSelecionado();
        string ObterEND_NUMERORegistroSelecionado();
        string ObterEND_CEPRegistroSelecionado();
        string ObterEND_UFRegistroSelecionado();
        string ObterTEL_NUMERORegistroSelecionado();

        void AtualizarGrade(object NovaLista);
        void FecharTelaComSucesso();
        void ExibirMensagemAviso(string Mensagem);
        void LimparCampoPesquisa();
        void AtualizarID(int COD_DISTRIBUIDORA, string DIST_NOME, string DIST_CNPJ, string END_RUA, string END_BAIRRO
            , string END_CIDADE, string END_NUMERO, string END_CEP, string END_UF, string TEL_NUMERO);
    }
}
