using Model.Class;
using Model.Interface;
using Presenter.Interface;
using Presenter.IView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Class
{
    public class ProdutosBuscarPresenter : IProdutosBuscarPresenter
    {
        IBuscarProdutos view;
        IProdutosModel model;
        public ProdutosBuscarPresenter(IBuscarProdutos View) {
            view = View;
            model = new ProdutosModel();

            view.LimparCampoPesquisa();
        }

        public void Pesquisar(string Texto = null)
        {
            IList<IProdutosModel> result;
            if (string.IsNullOrEmpty(Texto.Trim()))
                result = model.ConsultarTodos();
            else
                result = model.ConsultarPorNome(Texto);

            view.AtualizarGrade(result);
        }

        public void SelecionarRegistro()
        {
            try
            {
                view.AtualizarID(view.ObterIDRegistroSelecionado(), view.ObterNomeRegistroSelecionado(), view.ObterValorRegistroSelecionado(), view.ObterQtdRegistroSelecionado(), view.ObterNomeFabricanteRegistroSelecionado(), view.ObterNomeDistribuidoraRegistroSelecionado());
                view.FecharTelaComSucesso();
            }
            catch
            {
                view.ExibirMensagemAviso("Nenhum registro selecionado.");
            }
        }
    }
}
