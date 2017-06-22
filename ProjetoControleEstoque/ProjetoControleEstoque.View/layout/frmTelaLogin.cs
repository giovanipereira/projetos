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
    public partial class frmTelaLogin: Form
    {
        public frmTelaLogin()
        {
            InitializeComponent();
        }

        frmTelaSplash telaSplash;

        ControladorTelaLogin controladadorTelaLogin()
        {
            ControladorTelaLogin controladador = new ControladorTelaLogin(txtUsuario, txtSenha, btnEntrar);
            return controladador;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (controladadorTelaLogin().EfetuarLogin())
            {
                telaSplash = new frmTelaSplash();
                telaSplash.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorreto","Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Information);
                controladadorTelaLogin().LimparCampos();
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
