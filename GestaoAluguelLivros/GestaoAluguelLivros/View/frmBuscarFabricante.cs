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
    public partial class frmBuscarFabricante : GestaoAluguelLivros.View.frmBaseBuscar, IBuscarFabricante
    {
        IFabricanteBuscaPresenter presenter;
        public frmBuscarFabricante()
        {
            InitializeComponent();
            presenter = new FabricanteBuscaPresenter(this);

            DataGridViewColumn coluna = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            coluna.CellTemplate = cell;
            coluna.Name = "COD_FABRICANTE";
            coluna.HeaderText = "COD_FABRICANTE";
            coluna.DataPropertyName = "COD_FABRICANTE";
            coluna.Width = 50;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "FABR_NOME";
            coluna.HeaderText = "FABR_NOME";
            coluna.DataPropertyName = "FABR_NOME";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);
        }
        public int COD_FABRICANTE { get; private set; }
        public string FABR_NOME { get; private set; }

        public void AtualizarGrade(object NovaLista)
        {
            dgvResultadoPesquisa.DataSource = null;
            dgvResultadoPesquisa.DataSource = NovaLista;
        }

        public void AtualizarID(int COD_FABRICANTE, string FABR_NOME)
        {
            this.COD_FABRICANTE = COD_FABRICANTE;
            this.FABR_NOME = FABR_NOME;
        }

        public void ExibirMensagemAviso(string Mensagem)
        {
            MessageBox.Show(Mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void FecharTelaComSucesso()
        {
            DialogResult = DialogResult.OK;
        }

        public void LimparCampoPesquisa()
        {
            txtPesquisar.Clear();
            txtPesquisar.Select();
        }

        public int ObterCOD_FABRICANTERegistroSelecionado()
        {
            return int.Parse(dgvResultadoPesquisa.SelectedRows[0].Cells[0].Value.ToString());
        }

        public string ObterFABR_NOMERegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            presenter.Pesquisar(txtPesquisar.Text);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            presenter.SelecionarRegistro();
        }
    }
}
