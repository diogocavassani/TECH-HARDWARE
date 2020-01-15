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
    public partial class frmCadastroDistribuidora : GestaoAluguelLivros.frmBase,ICadastroDistribuidora
    {

        IDistribuidoraPresenter presenter;
        public frmCadastroDistribuidora()
        {
            InitializeComponent();
            presenter = new DistribuidoraPresenter(this);
        }
        public int COD_DISTRIBUIDORA
        {
            get
            {
                int.TryParse(txtCodigoDistribuidora.Text, out int id);
                return id;
            }
            set
            {
                txtCodigoDistribuidora.Text = value.ToString();
            }
        }

        public string DIST_NOME { get => txtNome.Text; set => txtNome.Text = value; }
        public string DIST_CNPJ { get => mskCPNJ.Text; set => mskCPNJ.Text = value; }
        public string END_RUA { get => txtRua.Text; set => txtRua.Text = value; }
        public string END_BAIRRO { get => txtBairro.Text; set => txtBairro.Text = value; }
        public string END_CIDADE { get => txtCidade.Text; set => txtCidade.Text = value; }
        public string END_NUMERO { get => txtNumero.Text; set => txtNumero.Text = value; }
        public string END_CEP { get => mskCEP.Text; set => mskCEP.Text = value; }
        public string END_UF { get => cmbUf.Text; set => cmbUf.Text = value; }
        public string TEL_NUMERO { get => mskTelefone.Text; set => mskTelefone.Text = value; }

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

        public void BloquearComponentes()
        {
            txtCodigoDistribuidora.Enabled = false;
            txtNome.Enabled = false;
            mskCPNJ.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtNumero.Enabled = false;
            mskCEP.Enabled = false;
            cmbUf.Enabled = false;
            mskTelefone.Enabled = false;
        }

        public void LiberarComponentes()
        {
            txtCodigoDistribuidora.Enabled = true;
            txtNome.Enabled = true;
            mskCPNJ.Enabled = true;
            txtRua.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtNumero.Enabled = true;
            mskCEP.Enabled = true;
            cmbUf.Enabled = true;
            mskTelefone.Enabled = true;
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

        public int BuscarDistribuidora()
        {
            frmBuscarDistribuidora tela = new frmBuscarDistribuidora();
            if (tela.ShowDialog() == DialogResult.OK)
                return tela.COD_DISTRIBUIDORA;
            else
                return 0;
        }

        public void MsgAlerta(string Mensagem)
        {
            MessageBox.Show(Mensagem, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
