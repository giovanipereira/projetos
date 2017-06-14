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
    public partial class frmTelaConsultaFuncionario : Form
    {
        public frmTelaConsultaFuncionario()
        {
            InitializeComponent();
        }

        ControladorTelaConsultaFuncionario controladorTelaConsultaFuncionario()
        {
            ControladorTelaConsultaFuncionario controlador = new ControladorTelaConsultaFuncionario(cboConsultarPor, txtValor,
                btnConsultar, btnExcluir, dgvConsultaFuncionarios);
            return controlador;
        }

        private void frmTelaConsultaFuncionario_Load(object sender, EventArgs e)
        {
            controladorTelaConsultaFuncionario().Load();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaFuncionario().Consultar();
        }

        private void cboConsultarPor_TextChanged(object sender, EventArgs e)
        {
            txtValor.Enabled = true;
        }
    }
}
