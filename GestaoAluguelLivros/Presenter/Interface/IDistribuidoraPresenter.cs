namespace Presenter.Interface
{
    public interface IDistribuidoraPresenter
    {
        void Novo();
        void Alterar();
        void Salvar();
        void Apagar();
        void LimparTela();
        void LiberarBloquearComponentes(bool Liberar);
        void FocarNoPrimeiroCampo();
        void ConsultarPorId(string ID);
        void Buscar();
    }
}