using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
  public  interface IBuscarFuncionario
    {
        
        int ObterIDRegistroSelecionado();
        string ObterNomeRegistroSelecionado();
        string ObterSobrenomeSelecionado();
        string ObterRuaSelecionado();
        string ObterBairroSelecionado();
        string ObterCidadeSelecionado();
        string ObterNumeroSelecionado();
        string ObterCEPSelecionado();
        string ObterUFSelecionado();
        string ObterTelefoneSelecionado();
        void AtualizarGrade(object NovaLista);
        void FecharTelaComSucesso();
        void ExibirMensagemAviso(string Mensagem);
        void LimparCampoPesquisa();
        void AtualizarID(int ID, string Nome, string Sobrenome, string Rua, string Bairro, string Cidade, string Numero, string Telefone, string UF, string CEP);
    }
}

