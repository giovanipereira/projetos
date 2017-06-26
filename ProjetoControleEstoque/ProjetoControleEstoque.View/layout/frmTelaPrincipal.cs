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

        private void frmTelaPrincipal_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string data = dt.ToString("dd/MM/yyyy");
            lblData.Text = data;
            lblHora.Text = (DateTime.Now.ToString("HH:mm:ss"));
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = (DateTime.Now.ToString("HH:mm:ss"));
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroFuncionario telaCadastroFuncionario = new frmTelaCadastroFuncionario((int)EnumOpcao.Cadastro);
            telaCadastroFuncionario.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroFornecedor telaCadastroFornecedor = new frmTelaCadastroFornecedor((int)EnumOpcao.Cadastro);
            telaCadastroFornecedor.ShowDialog();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroProduto telaCadastroProduto = new frmTelaCadastroProduto((int)EnumOpcao.Cadastro,1);
            telaCadastroProduto.ShowDialog();
        }

        private void cardápioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroCardapio telaCadastroCardapio = new frmTelaCadastroCardapio((int)EnumOpcao.Cadastro);
            telaCadastroCardapio.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmTelaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTelaConsultaProduto telaConsultaProduto = new frmTelaConsultaProduto(0);
            telaConsultaProduto.ShowDialog();
        }

        private void novoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroPedido telaCadastroPedido = new frmTelaCadastroPedido((int)EnumOpcao.Cadastro);
            telaCadastroPedido.ShowDialog();
        }

        private void funcionárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTelaConsultaFuncionario telaConsultaFuncionario = new frmTelaConsultaFuncionario();
            telaConsultaFuncionario.ShowDialog();
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTelaConsultaFornecedor telaConsultaFornecedor = new frmTelaConsultaFornecedor();
            telaConsultaFornecedor.ShowDialog();
        }

        private void cardápioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTelaConsultaCardapio telaConsultaCardapio = new frmTelaConsultaCardapio(0);
            telaConsultaCardapio.ShowDialog();
        }

        private void consultarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaConsultaPedido telaConsultaPedido = new frmTelaConsultaPedido();
            telaConsultaPedido.ShowDialog();
        }
    }
}
