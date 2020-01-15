using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
    public interface IBuscaCliente
    {
              
       int CodCliente { get; set; }
        int ObterIDRegistroSelecionado();
        string ObterNomeRegistroSelecionado();
        string ObterSobrenomeRegistroSelecionado();
        string ObterCpfRegistroSelecionado();
        string ObterSexoRegistroSelecionado();
        string ObterAtivoRegistroSelecionado();
        string ObterTelefoneRegistroSelecionado();
        DateTime ObterDataNascRegistroSelecionado();
        string ObterLogradouroRegistroSelecionado();
        string ObterNumeroRegistroSelecionado();
        string ObterBairroRegistroSelecionado();
        string ObterCidadeRegistroSelecionado();
        string ObterUFRegistroSelecionado();
        string ObterCepRegistroSelecionado();
        void AtualizarGrade(object NovaLista);
        void FecharTelaComSucesso();
        void ExibirMensagemAviso(string Mensagem);
        void LimparCampoPesquisa();
      
        void AtualizarID(int ID, string Nome, string sobrenome, string Cpf, DateTime DataNasc, string Sexo, string Ativo, string Telefone, string Logradouro, string Bairro, string Cidade,
            string Numero, string Cep, string UF);
    }
}
