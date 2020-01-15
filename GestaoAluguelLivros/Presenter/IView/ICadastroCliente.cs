using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
   public  interface ICadastroCliente
    {
        int Codigo { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }
        string Cpf { get; set; }
        string Sexo { get; set; }
        DateTime DataNascimento { get; set; }
        string Telefone { get; set; }        
        string Ativo { get; set; }
        string Rua { get; set; }
        string Bairro { get; set; }
        string Cidade { get; set; }
        string Numero { get; set; }
       
        string UF { get; set; }
        string CEP { get; set; }
        void BloquearComponentes();
        void LiberarComponentes();
        void FocarNoPrimeiroCampo();
        bool MsgSimNao(string Mensagem);
        int BuscarCliente();
        void MsgAlerta(string Mensagem);
    }
}
