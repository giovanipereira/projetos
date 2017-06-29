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
    public partial class frmTelaRelatorioPedido : Form
    {
        public frmTelaRelatorioPedido()
        {
            InitializeComponent();
        }

        private void frmTelaRelatorioPedido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetControleEstoque.historico_pedido' table. You can move, or remove it, as needed.
            this.historico_pedidoTableAdapter.Fill(this.dataSetControleEstoque.historico_pedido);

            this.reportViewer.RefreshReport();
        }
    }
}
