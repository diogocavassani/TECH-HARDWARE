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
  public  class FuncionarioBuscarPresenter : IFuncionarioBuscarPresenter
    {
        IBuscarFuncionario view;
        IFuncionarioModel model;

        public FuncionarioBuscarPresenter(IBuscarFuncionario View)
        {
            view = View;
            model = new FuncionarioModel();

            view.LimparCampoPesquisa();
        }
        public void Pesquisar(string Texto = null)
        {
            IList<IFuncionarioModel> result;
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
                view.AtualizarID(view.ObterIDRegistroSelecionado(), view.ObterNomeRegistroSelecionado(), view.ObterSobrenomeSelecionado(), view.ObterRuaSelecionado(), view.ObterBairroSelecionado(), view.ObterCidadeSelecionado(), view.ObterNumeroSelecionado(), view.ObterTelefoneSelecionado(), view.ObterUFSelecionado(), view.ObterCEPSelecionado());
                view.FecharTelaComSucesso();
            }
            catch
            {
                view.ExibirMensagemAviso("Nenhum registro selecionado.");
            }
        }
    }
}

