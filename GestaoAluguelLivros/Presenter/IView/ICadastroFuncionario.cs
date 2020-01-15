using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.IView
{
   public interface ICadastroFuncionario
    {
        int Codigo { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }
        bool Fun_Ativo { get; set; }
        string Rua { get; set; }
        string Bairro { get; set; }
        string Cidade { get; set; }
        string Numero { get; set; }
        string Telefone { get; set; }
        string UF { get; set; }
        string CEP { get; set; }


        void BloquearComponentes();
        void LiberarComponentes();
        void FocarNoPrimeiroCampo();
        bool MsgSimNao(string Mensagem);
        int BuscarAutor();
        void MsgAlerta(string Mensagem);
    }
}
