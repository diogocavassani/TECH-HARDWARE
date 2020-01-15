using GestaoAluguelLivros.View;
using Presenter.Class;
using Presenter.Interface;
using Presenter.IView;
using System;
using System.Windows.Forms;

namespace GestaoAluguelLivros
{
    public partial class frmCadastroFuncionarios : GestaoAluguelLivros.frmBase, ICadastroFuncionario
    {
        IFuncionarioPresenter presenter;

        public frmCadastroFuncionarios()
        {
            InitializeComponent();

            presenter = new FuncionarioPresenter(this);
        }

        public int Codigo
        {
            get
            {
                int.TryParse(txtCodigo.Text, out int id);
                return id;
            }
            set
            {
                txtCodigo.Text = value.ToString();
            }
        }
        public string Nome { get => txtNome.Text; set => txtNome.Text = value; }

        public string Sobrenome { get => txtSobrenome.Text; set => txtSobrenome.Text = value; }
        public string Rua { get => txtRua.Text; set => txtRua.Text = value; }
        public string Bairro { get => txtBairro.Text; set => txtBairro.Text = value; }
        public string Cidade { get => txtCidade.Text; set => txtCidade.Text = value; }
        public string Cep { get => mskCep.Text; set => mskCep.Text = value; }
        public string Telefone {
            get  {
                mskTel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string texto = mskTel.Text;
                mskTel.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                return texto;
            }
             set => mskTel.Text = value; }
        public string CEP { get
            {
                mskCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string texto = mskCep.Text;
                mskCep.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                return texto;
            } set => mskCep.Text = value; }
        public string UF { get => txtUf.Text; set => txtUf.Text = value; }
        public string Numero { get => txtNumero.Text; set => txtNumero.Text = value;}
        public bool Fun_Ativo { get; set; }


        public void BloquearComponentes()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtSobrenome.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled =false;
            txtRua.Enabled = false;
            txtUf.Enabled = false;
            mskTel.Enabled = false;
            mskCep.Enabled = false;
            txtNumero.Enabled = false;
        }

        public void LiberarComponentes()
        {
            txtCodigo.Enabled = true;
            txtNome.Enabled = true;
            txtSobrenome.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtRua.Enabled = true;
            txtUf.Enabled = true;
            mskTel.Enabled = true;
            mskCep.Enabled = true;
            txtNumero.Enabled = true;
        }

        public int BuscarAutor()
        {
            frmBuscarFuncionarios tela = new frmBuscarFuncionarios();
            if (tela.ShowDialog() == DialogResult.OK)
                return tela.IDRegistro;
            else
                return 0;
        }

        public void FocarNoPrimeiroCampo()
        {
            txtNome.Select();
        }

        public bool MsgSimNao(string Mensagem)
        {
            return (MessageBox.Show(Mensagem,
                "Pergunta", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            presenter.Novo();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            presenter.Alterar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            presenter.Apagar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            presenter.Buscar();
        }

        public void MsgAlerta(string Mensagem)
        {
            MessageBox.Show(Mensagem, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}