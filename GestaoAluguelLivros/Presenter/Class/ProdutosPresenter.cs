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
    public class ProdutosPresenter : IProdutosPresenter
    {
        IProdutosModel model;
        ICadastroProdutos view;

        public ProdutosPresenter(ICadastroProdutos View) {
            view = View;
            model = new ProdutosModel();
            LiberarBloquearComponentes(false);
        }

        public void Alterar()
        {
            if (view.Codigo > 0)
                LiberarBloquearComponentes(true);
        }

        public void Apagar()
        {
            if ((view.Codigo > 0) &&
                (view.MsgSimNao("Deseja realmente apagar este produto?")))
            {
                model = new ProdutosModel();
                model.Codigo = view.Codigo;
                model.Apagar();
                LimparTela();
                LiberarBloquearComponentes(false);
            }
        }

        public void Buscar()
        {
            int id = view.BuscarProdutos();

            if (id > 0)
            {
                ConsultarPorId(id);
                LiberarBloquearComponentes(false);
            }
        }

        public void ConsultarPorId(int ID)
        {
            model = model.ConsultarPorId(ID);
            view.Codigo = model.Codigo;
            view.Nome = model.Nome;
            view.ValorUnitario = model.ValorUnitario;
            view.Quantidade = model.Quantidade;
            view.codFabricante = model.codFabricante;
            view.codDistribuidora = model.codDistribuidora;
        }

        public void ObterFabricantes() {
            IList<IProdutosModel> listaFabricantes = model.ObterFabricantes();
            view.AtualizarFabricantes(listaFabricantes);
        }
        public void ObterDistribuidora()
        {
            IList<IProdutosModel> listaDistribuidora = model.ObterDistribuidora();
            view.AtualizarDistribuidoras(listaDistribuidora);
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
            view.Codigo = 0;
            view.Nome = "";
            view.ValorUnitario = 0;
            view.Quantidade = 0;
            view.Fabricante = "Selecione";
            view.Distribuidora = "Selecione";
        }

        public void Novo()
        {
            LimparTela();
            LiberarBloquearComponentes(true);
            FocarNoPrimeiroCampo();
        }

        public void Salvar()
        {
            model = new ProdutosModel();
            model.Codigo = view.Codigo;
            model.Nome = view.Nome;
            model.ValorUnitario = view.ValorUnitario;
            model.Quantidade = view.Quantidade;
            model.codFabricante = view.codFabricante;
            model.codDistribuidora = view.codDistribuidora;
            model.Fabricante = view.Fabricante;
            model.Distribuidora = view.Distribuidora;

            if (model.Validar(out string alertas))
            {
                if (model.Codigo == 0)
                    view.Codigo = model.Inserir();
                else
                    model.Alterar();

                LiberarBloquearComponentes(false);
            }
            else
            {
                view.MsgAlerta(alertas);
            }
        }
    }
}
