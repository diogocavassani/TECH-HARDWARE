using Model.Class;
using Model.Interface;
using Presenter.Interface;
using Presenter.IView;
using System;

namespace Presenter.Class
{
    public class DistribuidoraPresenter : IDistribuidoraPresenter
    {
        IDistribuidoraModel model;
        ICadastroDistribuidora view;

        public DistribuidoraPresenter(ICadastroDistribuidora View)
        {
            view = View;
            model = new DistribuidoraModel();
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
            if (view.COD_DISTRIBUIDORA > 0)
                LiberarBloquearComponentes(true);
        }

        public void Salvar()
        {
            model = new DistribuidoraModel();
            model.COD_DISTRIBUIDORA = view.COD_DISTRIBUIDORA;
            model.DIST_NOME = view.DIST_NOME;
            model.DIST_CNPJ = view.DIST_CNPJ;
            model.END_RUA = view.END_RUA;
            model.END_BAIRRO = view.END_BAIRRO;
            model.END_CIDADE = view.END_CIDADE;
            model.END_NUMERO = view.END_NUMERO;
            model.END_CEP = view.END_CEP;
            model.END_UF = view.END_UF;
            model.TEL_NUMERO = view.TEL_NUMERO;

            if (model.Validar(out string alertas))
            {
                if (model.COD_DISTRIBUIDORA == 0)
                    view.COD_DISTRIBUIDORA = model.Inserir();
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
            if ((view.COD_DISTRIBUIDORA > 0) &&
                (view.MsgSimNao("Deseja realmente apagar essa distribuidora?")))
            {
                model = new DistribuidoraModel();
                model.COD_DISTRIBUIDORA = view.COD_DISTRIBUIDORA;
                model.Apagar();
                LimparTela();
                LiberarBloquearComponentes(false);
            }
        }

        public void Buscar()
        {
            int id = view.BuscarDistribuidora();

            if (id > 0)
            {
                ConsultarPorId(id.ToString());
                LiberarBloquearComponentes(false);
            }
        }

        public void ConsultarPorId(string ID)
        {
            model = model.ConsultarPorId(ID);

            view.COD_DISTRIBUIDORA = model.COD_DISTRIBUIDORA;
            view.DIST_NOME = model.DIST_NOME;
            view.DIST_CNPJ = model.DIST_CNPJ;
            view.END_RUA = model.END_RUA;
            view.END_BAIRRO = model.END_BAIRRO;
            view.END_CIDADE = model.END_CIDADE;
            view.END_NUMERO = model.END_NUMERO;
            view.END_CEP = model.END_CEP;
            view.END_UF = model.END_UF;
            view.TEL_NUMERO = model.TEL_NUMERO;
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
            view.COD_DISTRIBUIDORA = 0;
            view.DIST_NOME = "";
            view.DIST_CNPJ = "";

            view.END_RUA = "";
            view.END_BAIRRO = "";
            view.END_CIDADE = "";
            view.END_NUMERO = "";
            view.END_CEP = "";
            view.END_UF = "";

            view.TEL_NUMERO = "";
        }

    }
}