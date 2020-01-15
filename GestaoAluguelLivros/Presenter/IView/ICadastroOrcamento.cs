using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
    public interface ICadastroOrcamento
    {
        int CodigoOrcamento { get; set; }
        decimal TotalOrcamento { get; set; }
        int CodigoCliente { get; set; }
        string NomeCliene { get; set; }
        int CodigoFuncionario { get; set; }
        string NomeFuncionario { get; set; }
        int CodigoProduto { get; set; }
        string NomeProduto { get; set; }
        decimal ValorProduto { get; set; }
        decimal TotalProduto { get; set; }

        void BloquearComponentes();
        void LiberarComponentes();
        void FocarNoPrimeiroCampo();
        bool MSgSimNao(string Mensagem);
        int BuscarOrcamento();
        void MsgAlerta(string Mensagem);
        void AtualizarClientes(IList<IClienteModel>listaClientes);
        void AtualizarFuncionarios(IList<IFuncionarioModel>listaFuncionarios);
        void AtualizarProdutos(IList<IProdutosModel>listaProdutos);
        void AtualizarGradeProdutos(object NovaLista);
        


    }
}
