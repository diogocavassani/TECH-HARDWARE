namespace Presenter.IView
{
    public interface ICadastroFabricante
    {
        int COD_FABRICANTE { get; set; }
        string FABR_NOME { get; set; }

        void BloquearComponentes();
        void LiberarComponentes();
        void FocarNoPrimeiroCampo();
        bool MsgSimNao(string Mensagem);
        int BuscarFabricante();
        void MsgAlerta(string Mensagem);
    }
}