namespace Presenter.IView
{
    public interface ICadastroDistribuidora
    {
        int COD_DISTRIBUIDORA { get; set; }
        string DIST_NOME { get; set; }
        string DIST_CNPJ { get; set; }
        string END_RUA { get; set; }
        string END_BAIRRO { get; set; }
        string END_CIDADE { get; set; }
        string END_NUMERO { get; set; }
        string END_CEP { get; set; }
        string END_UF { get; set; }
        string TEL_NUMERO { get; set; }

        void BloquearComponentes();
        void LiberarComponentes();
        void FocarNoPrimeiroCampo();
        bool MsgSimNao(string Mensagem);
        int BuscarDistribuidora();
        void MsgAlerta(string Mensagem);
    }
}