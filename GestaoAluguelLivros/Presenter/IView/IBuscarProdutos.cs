using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
    public interface IBuscarProdutos
    {
        int ObterIDRegistroSelecionado();
        string ObterNomeRegistroSelecionado();
        string ObterValorRegistroSelecionado();
        string ObterQtdRegistroSelecionado();
        string ObterNomeFabricanteRegistroSelecionado();
        string ObterNomeDistribuidoraRegistroSelecionado();
        void AtualizarGrade(object NovaLista);
        void FecharTelaComSucesso();
        void ExibirMensagemAviso(string Mensagem);
        void LimparCampoPesquisa();
        void AtualizarID(int ID, string NomeProduto, string ValorProduto, string QtdProduto, string fabr_nome, string dist_nome);
    }
}