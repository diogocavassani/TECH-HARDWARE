using Model.Class;
using Presenter.Class;
using Presenter.Interface;
using Presenter.IView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestaoAluguelLivros.View
{
    public partial class frmCadastroCliente : GestaoAluguelLivros.frmBase,ICadastroCliente
    {
        IClientePresenter presenter;
        public frmCadastroCliente()
        {
            InitializeComponent();
            presenter = new ClientePresenter(this);
        }

        public int Codigo { get => int.Parse(txtCodigo.Text); set => txtCodigo.Text = value.ToString(); }
        public string Nome { get => txtNome.Text; set => txtNome.Text = value; }
        public string Sobrenome { get => txtSobrenome.Text; set => txtSobrenome.Text = value; }
        public string Cpf {
            get
            {

                txtCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string texto = txtCpf.Text;
                txtCpf.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                return texto;
            }
            set => txtCpf.Text = value;
        }
        public string Sexo
        {
            get
            {
                if (rdbMasculino.Checked)
                    return "M";
                else
                    return "F";
            }
            set
            {
                if (value == "M")
                    rdbMasculino.Checked = true;
                else
                    rdbFeminino.Checked = true;
            }
        }
        public DateTime DataNascimento { get => dtpDataNascimento.Value; set => dtpDataNascimento.Value = value; }
        public string Telefone {
            get
            {
                txtTelefoneFixo.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string texto = txtTelefoneFixo.Text;
                txtTelefoneFixo.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                return texto;
            }
            set => txtTelefoneFixo.Text = value;
        }
        public string Ativo { get ; set ; }
        public string Rua { get => txtLogradouro.Text; set => txtLogradouro.Text = value; }
        public string Bairro { get => txtBairro.Text; set => txtBairro.Text = value; }
        public string Cidade { get => txtCidade.Text; set => txtCidade.Text = value; }
        public string Numero { get => txtNumero.Text; set => txtNumero.Text = value; }
        public string UF
        {
            get => cmbUf.Text;
            set
            {
                cmbUf.SelectedIndex = cmbUf.FindString(value);
            }
        }
        public string CEP {
            get
            {
                txtCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string texto = txtCep.Text;
                txtCep.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                return texto;
            }
            set => txtCep.Text = value;
        }

        public void BloquearComponentes()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtSobrenome.Enabled = false;
            txtTelefoneFixo.Enabled = false;
            txtNumero.Enabled = false;
            txtLogradouro.Enabled = false;
            txtCpf.Enabled = false;
            txtBairro.Enabled = false;
            txtCep.Enabled = false;
            txtCidade.Enabled = false;
            
        }

        public int BuscarCliente()
        {
            frmBuscaCliente tela = new frmBuscaCliente();
            if (tela.ShowDialog() == DialogResult.OK)
                return tela.CodCliente;
            else
                return 0;
        }

        public void FocarNoPrimeiroCampo()
        {
            txtNome.Select();
        }

        public void LiberarComponentes()
        {
            txtCodigo.Enabled = true;
            txtNome.Enabled = true;
            txtSobrenome.Enabled = true;
            txtTelefoneFixo.Enabled = true;
            txtNumero.Enabled = true;
            txtLogradouro.Enabled = true;
            txtCpf.Enabled = true;
            txtBairro.Enabled = true;
            txtCep.Enabled = true;
            txtCidade.Enabled = true;
        }

        public void MsgAlerta(string Mensagem)
        {
            MessageBox.Show(Mensagem, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
