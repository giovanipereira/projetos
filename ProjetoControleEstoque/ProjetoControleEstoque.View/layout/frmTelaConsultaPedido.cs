using ProjetoControleEstoque.Controller.controlador;
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
    public partial class frmTelaConsultaPedido : Form
    {
        public frmTelaConsultaPedido()
        {
            InitializeComponent();
        }

        ControladorTelaConsultaPedido controladorTelaConsultaPedido()
        {
            ControladorTelaConsultaPedido controlador = new ControladorTelaConsultaPedido(dgvConsultaPedidos);
            return controlador;
        }

        private void frmTelaConsultaPedido_Load(object sender, EventArgs e)
        {
            controladorTelaConsultaPedido().Load();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
