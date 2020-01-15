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
    public partial class frmBaseBuscar : Form
    {
        public frmBaseBuscar()
        {
            InitializeComponent();
            dgvResultadoPesquisa.AutoGenerateColumns = false;
        }

        private void frmBaseBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar.PerformClick();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgvResultadoPesquisa_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }
    }
}
