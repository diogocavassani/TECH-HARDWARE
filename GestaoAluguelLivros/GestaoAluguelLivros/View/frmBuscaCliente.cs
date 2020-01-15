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
    public partial class frmBuscaCliente : GestaoAluguelLivros.View.frmBaseBuscar, IBuscaCliente
    {
        IClienteBuscaPresenter presenter;
        public frmBuscaCliente()
        {
            InitializeComponent();
            presenter = new ClienteBuscaPresenter(this);
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
            coluna.Name = "cpf";
            coluna.HeaderText = "Cpf";
            coluna.DataPropertyName = "Cpf";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "Sexo";
            coluna.HeaderText = "Sexo";
            coluna.DataPropertyName = "Sexo";
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResultadoPesquisa.Columns.Add(coluna);

            coluna = new DataGridViewColumn();
            coluna.CellTemplate = cell;
            coluna.Name = "Rua";
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
            coluna.DataPropertyName = "UF";
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
        public string Cpf { get; set; }
        public string sexo { get; set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Numero { get; private set; }
        public string Telefone { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }
        public int CodCliente { get; set; }
        public void AtualizarGrade(object NovaLista)
        {
            dgvResultadoPesquisa.DataSource = null;
            dgvResultadoPesquisa.DataSource = NovaLista;
        }

        public void AtualizarID(int ID, string Nome, string sobrenome, string Cpf, DateTime DataNasc, string Sexo, string Ativo, string Telefone, string Logradouro, string Bairro, string Cidade, string Numero, string Cep, string UF)
        {
            this.IDRegistro = ID;
            this.NomeRegistro = Nome;
            this.Sobrenome = sobrenome;
            this.Rua = Rua;
            this.sexo = Sexo;
            this.Cpf = Cpf;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.CEP = CEP;
            this.UF = UF;

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

       

        public string ObterAtivoRegistroSelecionado()
        {
            return "";
        }

        public string ObterBairroRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[6].Value.ToString());
        }

        public string ObterCepRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[11].Value.ToString());
        }

        public string ObterCidadeRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[7].Value.ToString());
        }

        public string ObterCpfRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[3].Value.ToString());
        }

        public DateTime ObterDataNascRegistroSelecionado()
        {
            return DateTime.Now;
        }

        public int ObterIDRegistroSelecionado()
        {
            return int.Parse(dgvResultadoPesquisa.SelectedRows[0].Cells[0].Value.ToString());
        }

        public string ObterLogradouroRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[5].Value.ToString());
        }

        public string ObterNomeRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[1].Value.ToString());
        }

        public string ObterNumeroRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[8].Value.ToString());
        }

        public string ObterSexoRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[4].Value.ToString());
        }

        public string ObterSobrenomeRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[2].Value.ToString());
        }

        public string ObterTelefoneRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[9].Value.ToString());
        }

        public string ObterUFRegistroSelecionado()
        {
            return (dgvResultadoPesquisa.SelectedRows[0].Cells[10].Value.ToString());
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
