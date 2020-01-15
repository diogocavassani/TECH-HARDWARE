using Presenter.IView;
using Presenter.Class;
using Presenter.Interface;
using System;
using System.Windows.Forms;

namespace GestaoAluguelLivros.View
{
    public partial class frmBuscarFuncionarios : GestaoAluguelLivros.View.frmBaseBuscar, IBuscarFuncionario
    {
        IFuncionarioBuscarPresenter presenter;

        public frmBuscarFuncionarios()
        {
            InitializeComponent();
            presenter = new FuncionarioBuscarPresenter(this);

            DataGridViewColumn coluna = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            coluna.CellTemplate = cell;
            coluna.Name = "codigo";
            coluna.HeaderText = "Código";
            coluna.DataPropertyName = "Codigo";
            coluna.Width = 50;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "nome";
            coluna.HeaderText = "Nome";
            coluna.DataPropertyName = "Nome";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "sobrenome";
            coluna.HeaderText = "Sobrenome";
            coluna.DataPropertyName = "Sobrenome";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "rua";
            coluna.HeaderText = "Rua";
            coluna.DataPropertyName = "Rua";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "bairro";
            coluna.HeaderText = "Bairro";
            coluna.DataPropertyName = "Bairro";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "cidade";
            coluna.HeaderText = "Cidade";
            coluna.DataPropertyName = "Cidade";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "numero";
            coluna.HeaderText = "Numero";
            coluna.DataPropertyName = "Numero";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "telefone";
            coluna.HeaderText = "Telefone";
            coluna.DataPropertyName = "Telefone";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "uf";
            coluna.HeaderText = "Uf";
            coluna.DataPropertyName = "Uf";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "cep";
            coluna.HeaderText = "Cep";
            coluna.DataPropertyName = "Cep";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

           

        }

        public int IDRegistro { get; private set; }
        public string NomeRegistro { get; private set; }
        public string Sobrenome { get; private set; }
         public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Numero { get; private set; }
        public string Telefone { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }
        public void AtualizarGrade(object NovaLista)
        {
            dgvResultadoPesquisa.DataSource = null;
            dgvResultadoPesquisa.DataSource = NovaLista;
        }

        public void AtualizarID(int ID, string Nome, string Sobrenome, string Rua, string Bairro, string Cidade, string Numero, string Telefone, string UF, string CEP)
        {
            this.IDRegistro = ID;
            this.NomeRegistro = Nome;
            this.Sobrenome = Sobrenome;
            this.Rua = Rua;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.Numero = Numero;
            this.Telefone = Telefone;
            this.UF = UF;
            this.CEP = CEP;

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

        public string ObterSobrenomeSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[2].Value.ToString();
        }
        public string ObterRuaSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[3].Value.ToString();
        }
        public string ObterBairroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[4].Value.ToString();
        }
        public string ObterCidadeSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[5].Value.ToString();
        }
        public string ObterNumeroSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[6].Value.ToString();
        }
        public string ObterCEPSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[7].Value.ToString();
        }
        public string ObterUFSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[8].Value.ToString();
        }
        public string ObterTelefoneSelecionado()
        {
            return dgvResultadoPesquisa.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            presenter.SelecionarRegistro();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            presenter.Pesquisar(txtPesquisar.Text);
        }
    }
}