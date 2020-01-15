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
    public class ClienteBuscaPresenter : IClienteBuscaPresenter
    {
        IBuscaCliente view;
        IClienteModel model;

        public ClienteBuscaPresenter(IBuscaCliente View)
        {
            view = View;
            model = new ClienteModel();

            view.LimparCampoPesquisa();
        }

        public void Pesquisar(string Texto = null )
        {
            IList<IClienteModel> result;
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
                view.AtualizarID(view.ObterIDRegistroSelecionado(), view.ObterNomeRegistroSelecionado(), view.ObterSobrenomeRegistroSelecionado(),
                                    view.ObterCpfRegistroSelecionado(), view.ObterDataNascRegistroSelecionado(), view.ObterSexoRegistroSelecionado(),
                                    view.ObterAtivoRegistroSelecionado(), view.ObterTelefoneRegistroSelecionado(), view.ObterLogradouroRegistroSelecionado(),
                                    view.ObterBairroRegistroSelecionado(), view.ObterCidadeRegistroSelecionado(), view.ObterNumeroRegistroSelecionado(),
                                     view.ObterCepRegistroSelecionado(), view.ObterUFRegistroSelecionado());
                view.FecharTelaComSucesso();

            }
            catch
            {
                view.ExibirMensagemAviso("Nenhum Registro Selecionado");
            }
        }
    }
}
