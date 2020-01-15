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
    public class OrcamentoPresenter : IOrcamentoPresenter
    {
        IOrcamentoModel model;
        ICadastroOrcamento view;

        public OrcamentoPresenter(ICadastroOrcamento View)
        {
            view = View;
            model = new OrcamentoModel();
            LiberarBloquearComponentes(false);
        }
        public void AdicionarProduto()
        {
            throw new NotImplementedException();
        }

        public void Aletar()
        {
            if (view.CodigoOrcamento > 0)
                LiberarBloquearComponentes(true);
        }

        public void Apagar()
        {
            if((view.CodigoOrcamento>0)&&(view.MSgSimNao("Deseja realmente excluir este orçamento?")))
            {
                model = new OrcamentoModel();
                model.Codigo = view.CodigoOrcamento;
                model.Apagar();
                LimparTela();
                LiberarBloquearComponentes(false);
            }
        }

        public void Buscar()
        {
            int id = view.BuscarOrcamento();
            if ( id > 0)
            {
                ConsultarPorId(id);
                LiberarBloquearComponentes(false);
            }
        }

        public void CalcularTotalProduto()
        {
            throw new NotImplementedException();
        }

        public void ConsultarPorId(int ID)
        {
            model.ConsultarporID(ID);
            view.CodigoOrcamento = model.Codigo;
         //   view.TotalOrcamento = model.va total orcamento deve-se ser calculado
            
        }

        public void FocarNoPrimeiroCampo()
        {
            view.FocarNoPrimeiroCampo();
        }

        public void LiberarBloquearComponentes(bool Liberar)
        {
            if (Liberar)
                view.LiberarComponentes();
            else
                view.BloquearComponentes();
        }

        public void LimparTela()
        {
            view.CodigoOrcamento = 0;
            view.TotalOrcamento = 0;
            view.CodigoCliente = 0;
            view.NomeCliene = "";
            view.CodigoProduto = 0;
            view.NomeProduto = "";
            view.ValorProduto = 0;
            view.TotalProduto = 0;
            view.AtualizarGradeProdutos(null); //deve-se passar uma lista vazia

        }

        public void Novo()
        {
            LimparTela();
            LiberarBloquearComponentes(true);
            FocarNoPrimeiroCampo();
        }

        public void ObterClientes()
        {
            throw new NotImplementedException();
        }

        public void ObterFunciorio()
        {
            throw new NotImplementedException();
        }

        public void ObterProduto()
        {
            throw new NotImplementedException();
        }

        public void RemoverProduto()
        {
            throw new NotImplementedException();
        }

        public void Salvar()
        {
            model = new OrcamentoModel();
            model.Codigo = view.CodigoOrcamento;
            model.CodigoCliente = view.CodigoCliente;
            model.CodigoFuncionario = view.CodigoFuncionario;
            model.NomeCliente = view.NomeCliene;
            model.NomeFuncionario = view.NomeFuncionario;
            
            


        }
    }
}
