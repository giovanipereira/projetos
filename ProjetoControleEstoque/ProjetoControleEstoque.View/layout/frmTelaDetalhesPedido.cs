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
    public partial class frmTelaDetalhesPedido : Form
    {
        public frmTelaDetalhesPedido()
        {
            InitializeComponent();
        }

        ControladorTelaDetalhesPedido controladorTelaDetalhesPedido()
        {
            ControladorTelaDetalhesPedido controlador = new ControladorTelaDetalhesPedido(btnFinalizar, btnCancelarPedido, lblCodigo);
            return controlador;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            controladorTelaDetalhesPedido().Finalizar(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            controladorTelaDetalhesPedido().Cancelar(this);
        }
    }
}
