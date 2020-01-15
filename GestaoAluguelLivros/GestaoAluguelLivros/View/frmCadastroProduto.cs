using GestaoAluguelLivros.View;
using Model.Interface;
using Presenter.Class;
using Presenter.Interface;
using Presenter.IView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoAluguelLivros
{
    public partial class frmCadastroProduto : GestaoAluguelLivros.frmBase, ICadastroProdutos
    {
        IProdutosPresenter presenter;

        public frmCadastroProduto()
        {
            InitializeComponent();

            presenter = new ProdutosPresenter(this);
            presenter.ObterFabricantes();
            presenter.ObterDistribuidora();
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
        public decimal ValorUnitario
        {
            get
            {
                Decimal.TryParse(txtValorUnitario.Text, out decimal valor);
                return valor;
            }
            set
            {
                txtValorUnitario.Text = value.ToString();
            }
        }
        public int Quantidade {
            get
            {
                int.TryParse(txtQuantidade.Text, out int qtd);
                return qtd;
            }
            set => txtQuantidade.Text = value.ToString(); }
        public int codFabricante {
            get
            {
                string[] arr = cmbFabricante.Text.Split('-');
                int.TryParse(arr[0].Trim(), out int fabricante);
                return fabricante;
            }
            set => cmbFabricante.Text = value.ToString(); }
        public int codDistribuidora
        {
            get
            {
                string[] arr = cmbDistribuidora.Text.Split('-');
                int.TryParse(arr[0].Trim(), out int distribuidora);
                return distribuidora;
            }
            set => cmbDistribuidora.Text = value.ToString(); }

        public string Fabricante { get => cmbFabricante.Text; set => cmbFabricante.Text = value; }
        public string Distribuidora { get => cmbDistribuidora.Text; set => cmbDistribuidora.Text = value; }
        public void BloquearComponentes()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtValorUnitario.Enabled = false;
            txtQuantidade.Enabled = false;
            cmbFabricante.Enabled = false;
            cmbDistribuidora.Enabled = false;
        }

        public void LiberarComponentes()
        {
            txtCodigo.Enabled = true;
            txtNome.Enabled = true;
            txtValorUnitario.Enabled = true;
            txtQuantidade.Enabled = true;
            cmbFabricante.Enabled = true;
            cmbDistribuidora.Enabled = true;
        }

        public int BuscarProdutos()
        {
            frmBuscarProdutos tela = new frmBuscarProdutos();
            if (tela.ShowDialog() == DialogResult.OK)
               return tela.IDRegistro;
            else
               return 0;
        }

        public void AtualizarFabricantes(IList<IProdutosModel> listaFabricantes) {
            cmbFabricante.DisplayMember = "Text";
            cmbFabricante.ValueMember = "Value";

            foreach (var item in listaFabricantes)
            {
                cmbFabricante.Items.Add(item.codFabricante + " - " + item.Fabricante);
            }
        }

        public void AtualizarDistribuidoras(IList<IProdutosModel> listaDistribuidoras)
        {
            cmbDistribuidora.DisplayMember = "Text";
            cmbDistribuidora.ValueMember = "Value";

            foreach (var item in listaDistribuidoras)
            {
                cmbDistribuidora.Items.Add(item.codDistribuidora + " - " + item.Distribuidora);
            }
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