using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoAluguelLivros.View
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        

        private void EscondeButtons()
        {
            if(btnCliente.Visible == false)
            {
                btnCliente.Visible = true;
                btnDistribuidora.Visible = true;
                btnFabricante.Visible = true;
                btnFuncionario.Visible = true;
                btnProduto.Visible = true;
                btnCadastros.BackColor = Color.FromArgb(73, 81, 65);
            }
            else
            {
                btnCliente.Visible = false;
                btnDistribuidora.Visible = false;
                btnFabricante.Visible = false;
                btnFuncionario.Visible = false;
                btnProduto.Visible = false;
                btnCadastros.BackColor = Color.FromArgb(47, 50, 58);
            }
        }
        private void btnCadastros_Click(object sender, EventArgs e)
        {
            EscondeButtons();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnCliente.Visible = false;
            btnDistribuidora.Visible = false;
            btnFabricante.Visible = false;
            btnFuncionario.Visible = false;
            btnProduto.Visible = false;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCadastroCliente tela = new frmCadastroCliente();
            tela.ShowDialog();
        }

        private void btnDistribuidora_Click(object sender, EventArgs e)
        {
            frmCadastroDistribuidora tela = new frmCadastroDistribuidora();
            tela.ShowDialog();
        }

        private void btnFabricante_Click(object sender, EventArgs e)
        {
            frmCadastroFabricante tela = new frmCadastroFabricante();
            tela.ShowDialog();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            frmCadastroFuncionarios tela = new frmCadastroFuncionarios();
            tela.ShowDialog();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            frmCadastroProduto tela = new frmCadastroProduto();
            tela.ShowDialog();
        }
    }
}
