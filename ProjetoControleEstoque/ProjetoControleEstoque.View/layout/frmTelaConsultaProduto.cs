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
    public partial class frmTelaConsultaProduto : Form
    {
        public frmTelaConsultaProduto()
        {
            InitializeComponent();
        }

        ControladorTelaConsultaProduto controladorTelaConsultaProduto()
        {
            ControladorTelaConsultaProduto controlador = new ControladorTelaConsultaProduto(cboConsultarPor, txtValor,
                btnConsultar, btnAdicionar, btnExcluir, dgvConsultaProdutos);
            return controlador;
        }

        private void frmTelaConsultaProduto_Load(object sender, EventArgs e)
        {
            controladorTelaConsultaProduto().Load();
        }

        private void cboConsultarPor_TextChanged(object sender, EventArgs e)
        {
            txtValor.Enabled = true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaProduto().Consultar();
        }
    }
}
