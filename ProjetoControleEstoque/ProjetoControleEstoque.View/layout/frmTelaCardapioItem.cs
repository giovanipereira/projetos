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
    public partial class frmTelaCardapioItem : Form
    {
        public frmTelaCardapioItem()
        {
            InitializeComponent();
        }

        public frmTelaCadastroCardapio telaCadastroCardapio;

         private ControladorTelaCardapioItem controladorTelaCardapioItem()
         {
             ControladorTelaCardapioItem controlador = new ControladorTelaCardapioItem(txtCodigoProduto, txtNomeProduto,
                 txtQuantidadeProduto, cboUnidadeProduto, btnAdicionar, btnAtualizar, btnCancelar);
             return controlador;
         }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            telaCadastroCardapio = new frmTelaCadastroCardapio();
            telaCadastroCardapio.quantidade = (txtQuantidadeProduto.Text);
            this.Hide();
        }

        private void frmTelaCardapioItem_Load(object sender, EventArgs e)
        {
        }
    }
}
