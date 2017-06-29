using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.View.layout
{
    public partial class frmTelaRelatorioEntradaProduto : Form
    {
        public frmTelaRelatorioEntradaProduto()
        {
            InitializeComponent();
        }

        private void frmTelaRelatorioEntradaProduto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetControleEstoque.historico_produto' table. You can move, or remove it, as needed.
            this.historico_produtoTableAdapter.Fill(this.dataSetControleEstoque.historico_produto);

            this.reportViewer.RefreshReport();
        }
    }
}
