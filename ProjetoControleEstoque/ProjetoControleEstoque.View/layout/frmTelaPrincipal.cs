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
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(SplashScreen));
            System.Threading.Thread.Sleep(1000);
            InitializeComponent();
            t.Abort();
        }

        public void SplashScreen()
        {
            Application.Run(new frmTelaSplash());

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
            frmTelaCadastroFuncionario telaCadastroFuncionario = new frmTelaCadastroFuncionario();
            telaCadastroFuncionario.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroFornecedor telaCadastroFornecedor = new frmTelaCadastroFornecedor();
            telaCadastroFornecedor.ShowDialog();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroProduto telaCadastroProduto = new frmTelaCadastroProduto();
            telaCadastroProduto.ShowDialog();
        }

        private void cardápioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroCardapio telaCadastroCardapio = new frmTelaCadastroCardapio();
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
            frmTelaConsultaProduto telaConsultaProduto = new frmTelaConsultaProduto();
            telaConsultaProduto.ShowDialog();
        }

        private void novoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaCadastroPedido telaCadastroPedido = new frmTelaCadastroPedido();
            telaCadastroPedido.ShowDialog();
        }
    }
}
