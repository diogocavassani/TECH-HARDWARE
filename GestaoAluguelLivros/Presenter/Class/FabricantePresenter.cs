using Model.Class;
using Model.Interface;
using Presenter.Interface;
using Presenter.IView;
using System;

namespace Presenter.Class
{
    public class FabricantePresenter : IFabricantePresenter
    {
        IFabricanteModel model;
        ICadastroFabricante view;

        public FabricantePresenter(ICadastroFabricante View)
        {
            view = View;
            model = new FabricanteModel();
            LiberarBloquearComponentes(false);
        }

        public void Novo()
        {
            LimparTela();
            LiberarBloquearComponentes(true);
            FocarNoPrimeiroCampo();
        }

        public void Alterar()
        {
            if (view.COD_FABRICANTE > 0)
                LiberarBloquearComponentes(true);
        }

        public void Salvar()
        {
            model = new FabricanteModel();
            model.COD_FABRICANTE = view.COD_FABRICANTE;
            model.FABR_NOME = view.FABR_NOME;


            if (model.Validar(out string alertas))
            {
                if (model.COD_FABRICANTE == 0)
                    view.COD_FABRICANTE = model.Inserir();
                else
                    model.Alterar();

                LiberarBloquearComponentes(false);
            }
            else
            {
                view.MsgAlerta(alertas);
            }
        }

        public void Apagar()
        {
            if ((view.COD_FABRICANTE > 0) &&
                (view.MsgSimNao("Deseja realmente apagar essa fabricante?")))
            {
                model = new FabricanteModel();
                model.COD_FABRICANTE = view.COD_FABRICANTE;
                model.Apagar();
                LimparTela();
                LiberarBloquearComponentes(false);
            }
        }

        public void Buscar()
        {
            int id = view.BuscarFabricante();

            if (id > 0)
            {
                ConsultarPorId(id.ToString());
                LiberarBloquearComponentes(false);
            }
        }

        public void ConsultarPorId(string ID)
        {
            model = model.ConsultarPorId(ID);

            view.COD_FABRICANTE = model.COD_FABRICANTE;
            view.FABR_NOME = model.FABR_NOME;

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
            view.COD_FABRICANTE = 0;
            view.FABR_NOME = "";

        }

    }
}