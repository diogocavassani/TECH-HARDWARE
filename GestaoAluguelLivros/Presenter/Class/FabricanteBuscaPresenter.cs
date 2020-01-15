using Model.Class;
using Model.Interface;
using Presenter.IView;
using Presenter.Interface;
using System.Collections.Generic;

namespace Presenter.Class
{
    public class FabricanteBuscaPresenter : IFabricanteBuscaPresenter
    {
        IBuscarFabricante view;
        IFabricanteModel model;

        public FabricanteBuscaPresenter(IBuscarFabricante View)
        {
            view = View;
            model = new FabricanteModel();

            view.LimparCampoPesquisa();
        }

        public void Pesquisar(string Texto = null)
        {
            IList<IFabricanteModel> result;
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
                view.AtualizarID(view.ObterCOD_FABRICANTERegistroSelecionado(), view.ObterFABR_NOMERegistroSelecionado());
                view.FecharTelaComSucesso();
            }
            catch
            {
                view.ExibirMensagemAviso("Nenhum registro selecionado.");
            }
        }
    }
}