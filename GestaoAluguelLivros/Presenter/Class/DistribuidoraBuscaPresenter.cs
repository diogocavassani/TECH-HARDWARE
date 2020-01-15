using Model.Class;
using Model.Interface;
using Presenter.IView;
using Presenter.Interface;
using System.Collections.Generic;

namespace Presenter.Class
{
    public class OrcamentoBuscaPresenter : IDistribuidoraBuscaPresenter
    {
        IBuscarDistribuidora view;
        IDistribuidoraModel model;

        public OrcamentoBuscaPresenter(IBuscarDistribuidora View)
        {
            view = View;
            model = new DistribuidoraModel();
            view.LimparCampoPesquisa();
        }

        public void Pesquisar(string Texto = null)
        {
            IList<IDistribuidoraModel> result;
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
                view.AtualizarID(view.ObterCOD_DISTRIBUIDORARegistroSelecionado(), view.ObterDIST_NOMERegistroSelecionado(), view.ObterDIST_CNPJRegistroSelecionado(),
                    view.ObterEND_RUARegistroSelecionado(), view.ObterEND_BAIRRORegistroSelecionado(), view.ObterEND_CIDADERegistroSelecionado(), view.ObterEND_NUMERORegistroSelecionado()
                    , view.ObterEND_CEPRegistroSelecionado(), view.ObterEND_UFRegistroSelecionado(), view.ObterTEL_NUMERORegistroSelecionado());
                view.FecharTelaComSucesso();
            }
            catch
            {
                view.ExibirMensagemAviso("Nenhum registro selecionado.");
            }
        }
    }
}