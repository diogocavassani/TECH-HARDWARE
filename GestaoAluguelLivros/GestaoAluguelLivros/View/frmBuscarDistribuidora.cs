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
    public partial class frmBuscarDistribuidora : GestaoAluguelLivros.View.frmBaseBuscar,IBuscarDistribuidora
    {
        IDistribuidoraBuscaPresenter presenter;
        public frmBuscarDistribuidora()
        {
            InitializeComponent();
            presenter = new OrcamentoBuscaPresenter(this);

            DataGridViewColumn coluna = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            coluna.CellTemplate = cell;
            coluna.Name = "COD_DISTRIBUIDORA";
            coluna.HeaderText = "COD_DISTRIBUIDORA";
            coluna.DataPropertyName = "COD_DISTRIBUIDORA";
            coluna.Width = 50;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "DIST_NOME";
            coluna.HeaderText = "DIST_NOME";
            coluna.DataPropertyName = "DIST_NOME";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "DIST_CNPJ";
            coluna.HeaderText = "DIST_CNPJ";
            coluna.DataPropertyName = "DIST_CNPJ";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "END_RUA";
            coluna.HeaderText = "END_RUA";
            coluna.DataPropertyName = "END_RUA";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "END_BAIRRO";
            coluna.HeaderText = "END_BAIRRO";
            coluna.DataPropertyName = "END_BAIRRO";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "END_CIDADE";
            coluna.HeaderText = "END_CIDADE";
            coluna.DataPropertyName = "END_CIDADE";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "END_NUMERO";
            coluna.HeaderText = "END_NUMERO";
            coluna.DataPropertyName = "END_NUMERO";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);
            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "END_CEP";
            coluna.HeaderText = "END_CEP";
            coluna.DataPropertyName = "END_CEP";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "END_UF";
            coluna.HeaderText = "END_UF";
            coluna.DataPropertyName = "END_UF";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "TEL_NUMERO";
            coluna.HeaderText = "TEL_NUMERO";
            coluna.DataPropertyName = "TEL_NUMERO";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

        }

        public int COD_DISTRIBUIDORA { get; private set; }
        public string DIST_NOME { get; private set; }
        public string DIST_CNPJ { get; private set; }
        public string END_RUA { get; private set; }
        public string END_BAIRRO { get; private set; }
        public string END_CIDADE { get; private set; }
        public string END_NUMERO { get; private set; }
        public string END_CEP { get; private set; }
        public string END_UF { get; private set; }
        public string TEL_NUMERO { get; private set; }

        public void AtualizarGrade(object NovaLista)
        {
            dgvResultadoPesquisa.DataSource = null;
            dgvResultadoPesquisa.DataSource = NovaLista;
        }

        public void AtualizarID(int COD_DISTRIBUIDORA, string DIST_NOME, string DIST_CNPJ, string END_RUA
            , string END_BAIRRO, string END_CIDADE, string END_NUMERO, string END_CEP
            , string END_UF, string TEL_NUMERO)
        {
            this.COD_DISTRIBUIDORA = COD_DISTRIBUIDORA;
            this.DIST_NOME = DIST_NOME;
            this.DIST_CNPJ = DIST_CNPJ;
            this.END_RUA = END_RUA;
            this.END_BAIRRO = END_BAIRRO;
            this.END_CIDADE = END_CIDADE;
            this.END_NUMERO = END_NUMERO;
            this.END_CEP = END_CEP;
            this.END_UF = END_UF;
            this.TEL_NUMERO = TEL_NUMERO;
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


        public int ObterCOD_DISTRIBUIDORARegistroSelecionado()
        {
            return int.Parse(dgvResultadoPesquisa.SelectedRows[0].Cells[0].Value.ToString());
        }

        public string ObterDIST_NOMERegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[1].Value.ToString();
        }
        public string ObterDIST_CNPJRegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[2].Value.ToString();
        }
        public string ObterEND_RUARegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[3].Value.ToString();
        }
        public string ObterEND_BAIRRORegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[4].Value.ToString();
        }
        public string ObterEND_CIDADERegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[5].Value.ToString();
        }
        public string ObterEND_NUMERORegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[6].Value.ToString();
        }
        public string ObterEND_CEPRegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[7].Value.ToString();
        }
        public string ObterEND_UFRegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[8].Value.ToString();
        }
        public string ObterTEL_NUMERORegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[9].Value.ToString();
        }       

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            presenter.Pesquisar(txtPesquisar.Text);
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            presenter.SelecionarRegistro();
        }

    }
}
