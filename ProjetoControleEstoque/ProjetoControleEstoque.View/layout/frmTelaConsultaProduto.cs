using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoControleEstoque.Controller.controlador;

namespace ProjetoControleEstoque.View.layout
{
    public partial class frmTelaConsultaProduto : Form
    {
        public frmTelaConsultaProduto()
        {
            InitializeComponent();
        }

        private ControladorTelaConsultaProduto controladorTelaConsultaProduto()
        {
            ControladorTelaConsultaProduto controlador = new ControladorTelaConsultaProduto(cboFiltro, txtBusca,
            btnBuscar, btnBuscarTodos, btnAdicionar, dgvListaProdutos);
            return controlador;
        }

        frmTelaCardapioItem telaCardapioItem;

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
           // NomeDaColuna.HeaderText = "Titulo da Coluna";
         /*  private void AdjustColumnOrder()
        {
            customersDataGridView.Columns["CustomerID"].Visible = false;
            customersDataGridView.Columns["ContactName"].DisplayIndex = 0;
            customersDataGridView.Columns["ContactTitle"].DisplayIndex = 1;
            customersDataGridView.Columns["City"].DisplayIndex = 2;
            customersDataGridView.Columns["Country"].DisplayIndex = 3;
            customersDataGridView.Columns["CompanyName"].DisplayIndex = 4;
        }*/ 
    }

        private void frmTelaConsultaProduto_Load(object sender, EventArgs e)
        {
            controladorTelaConsultaProduto().Load();
            dgvListaProdutos.AutoGenerateColumns = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            telaCardapioItem = new frmTelaCardapioItem();
            controladorTelaConsultaProduto().AddProduct(telaCardapioItem);
            this.Hide();
        }

        private void dgvListaProdutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
            {
                DataGridViewRow row = dgvListaProdutos.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = Color.Yellow;
                row.DefaultCellStyle.ForeColor = Color.Aquamarine;
            }
        }
    }
}
