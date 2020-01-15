using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
    public interface ICadastroProdutos
    {
        int Codigo { get; set; }
        string Nome { get; set; }
        decimal ValorUnitario { get; set; }
        int Quantidade { get; set; }
        int codFabricante { get; set; }
        int codDistribuidora { get; set; }
        string Fabricante { get; set; }
        string Distribuidora { get; set; }
        void BloquearComponentes();
        void LiberarComponentes();
        void FocarNoPrimeiroCampo();
        bool MsgSimNao(string Mensagem);
        int BuscarProdutos();
        void MsgAlerta(string Mensagem);
        void AtualizarFabricantes(IList<IProdutosModel> listaFabricantes);
        void AtualizarDistribuidoras(IList<IProdutosModel> listaDistribuidoras);
    }
}
