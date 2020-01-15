using Presenter.Class;
using Presenter.Interface;
using Presenter.IView;
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
    public partial class frmBuscarProdutos : GestaoAluguelLivros.View.frmBaseBuscar, IBuscarProdutos
    {
        IProdutosBuscarPresenter presenter;
        public frmBuscarProdutos()
        {
            InitializeComponent();
            presenter = new ProdutosBuscarPresenter(this);

            DataGridViewColumn coluna = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            coluna.CellTemplate = cell;
            coluna.Name = "codigo";
            coluna.HeaderText = "Código Produto";
            coluna.DataPropertyName = "Codigo";
            coluna.Width = 50;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "PROD_NOME";
            coluna.HeaderText = "Nome";
            coluna.DataPropertyName = "Nome";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "PROD_VALOR";
            coluna.HeaderText = "Valor";
            coluna.DataPropertyName = "ValorUnitario";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "EST_QUANTIDADE";
            coluna.HeaderText = "Valor";
            coluna.DataPropertyName = "Quantidade";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "FABR_NOME";
            coluna.HeaderText = "Fabricante";
            coluna.DataPropertyName = "Fabricante";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna); 

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "DIST_NOME";
            coluna.HeaderText = "Distribuidora";
            coluna.DataPropertyName = "Distribuidora";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);
        }
        public int IDRegistro { get; private set; }
        public string NomeProduto { get; private set; }
        public string ValorProduto { get; private set; }
        public string QuantidadeProduto { get; private set; }
        public string FabricanteNome { get; private set; }
        public string DistribuidoraNome { get; private set; }       


        public void AtualizarGrade(object NovaLista)
        {
            dgvResultadoPesquisa.DataSource = null;
            dgvResultadoPesquisa.DataSource = NovaLista;
        }

        public void AtualizarID(int ID, string NomeProduto, string ValorProduto, string QtdProduto, string fabr_nome, string dist_nome)
        {
            this.IDRegistro = ID;
            this.NomeProduto = NomeProduto;
            this.ValorProduto = ValorProduto;
            this.QuantidadeProduto = QtdProduto;
            this.FabricanteNome = fabr_nome;
            this.DistribuidoraNome = dist_nome;
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

        public int ObterIDRegistroSelecionado()
        {
            return int.Parse(dgvResultadoPesquisa.SelectedRows[0].Cells[0].Value.ToString());
        }

        public string ObterNomeRegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[1].Value.ToString();
        }

        public string ObterValorRegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[2].Value.ToString();
        }
        public string ObterQtdRegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[3].Value.ToString();
        }
        public string ObterNomeFabricanteRegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[4].Value.ToString();
        }
        public string ObterNomeDistribuidoraRegistroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            presenter.Pesquisar(txtPesquisar.Text);
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            presenter.SelecionarRegistro();
        }

        private void frmBuscarProdutos_Load(object sender, EventArgs e)
        {
        }
    }
}
