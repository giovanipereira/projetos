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
    public partial class frmTelaEscolherProduto : Form
    {
        public frmTelaEscolherProduto()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            frmTelaCadastroProduto telaCadastroProduto = new frmTelaCadastroProduto((int)EnumOpcao.Cadastro, 1);
            telaCadastroProduto.ShowDialog();
            this.Close();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmTelaConsultaProduto telaConsultaProduto = new frmTelaConsultaProduto(0);
            telaConsultaProduto.ShowDialog();
            this.Close();
        }
    }
}
