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
    public partial class frmCadastroFabricante : GestaoAluguelLivros.frmBase,ICadastroFabricante
    {
        IFabricantePresenter presenter;

        public frmCadastroFabricante()
        {
            InitializeComponent();

            presenter = new FabricantePresenter(this);
        }

        public int COD_FABRICANTE
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
        public string FABR_NOME { get => txtNome.Text; set => txtNome.Text = value; }

        public void BloquearComponentes()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
        }

        public int BuscarFabricante()
        {
            frmBuscarFabricante tela = new frmBuscarFabricante();
            if (tela.ShowDialog() == DialogResult.OK)
                return tela.COD_FABRICANTE;
            
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
