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
    public partial class frmTelaPrincipal : Form
    {
        public frmTelaPrincipal()
        {
            InitializeComponent();
        }
        
        private void btnCadastroCardapio_Click(object sender, EventArgs e)
        {
            frmTelaCadastroCardapio tela = new frmTelaCadastroCardapio();
            tela.Show();
            this.Hide();
        }

    }
}
