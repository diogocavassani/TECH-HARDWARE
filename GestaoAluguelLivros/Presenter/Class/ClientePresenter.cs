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
    public class ClientePresenter : IClientePresenter
    {
        IClienteModel model;
        ICadastroCliente view;

        public ClientePresenter(ICadastroCliente View)
        {
            view = View;
            model = new ClienteModel();
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
                 (view.MsgSimNao("Deseja realmente apagar este Funcionario?")))
            {
                model = new ClienteModel();
                model.Codigo = view.Codigo;
                model.Apagar();
                LimparTela();
                LiberarBloquearComponentes(false);
            }
        }

        public void Buscar()
        {
            int id = view.BuscarCliente();

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
            view.Sobrenome = model.Sobrenome;
            view.Rua = model.Rua;
            view.Bairro = model.Bairro;
            view.Cidade = model.Cidade;
            view.UF = model.UF;
            view.CEP = model.CEP;
            view.Telefone = model.Telefone;
            view.Numero = model.Numero;
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
            view.Sobrenome = "";
            view.Rua = "";
            view.Bairro = "";
            view.Cidade = "";
            view.Telefone = "";
            view.UF = "";
            view.CEP = "";
            view.Numero = "";
        }

        public void Novo()
        {
            LimparTela();
            LiberarBloquearComponentes(true);
            FocarNoPrimeiroCampo();
        }

        public void Salvar()
        {
            model = new ClienteModel();
            model.Codigo = view.Codigo;
            model.Nome = view.Nome;
            model.Sobrenome = view.Sobrenome;
            model.Sexo = view.Sexo;
            model.Cpf = view.Cpf;
            model.DataNascimento = view.DataNascimento;
            model.Rua = view.Rua;
            model.Telefone = view.Telefone;
            model.Numero = view.Numero;
            model.Bairro = view.Bairro;
            model.ATivo = view.Ativo;
            model.Cidade = view.Cidade;
            model.CEP = view.CEP;
            model.UF = view.UF;
            if (model.Validar(out string alertas))
            {
                if (model.Codigo == 0)
                    view.Codigo= model.Inserir();
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
