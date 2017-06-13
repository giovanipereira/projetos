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
    public partial class frmTelaCadastroFuncionario : Form
    {
        public frmTelaCadastroFuncionario()
        {
            InitializeComponent();
        }
        ControladorTelaCadastroFuncionario controladorTelaCadastroFuncionario()
        {
            ControladorTelaCadastroFuncionario controlador = new ControladorTelaCadastroFuncionario(txtCodigo,
                txtNome, txtEmail, txtUsuario, txtSenha, txtConfirmarSenha, cboCargo, cboNivelAcesso, mskCpf,
                mskTelefone, btnInserir,btnSalvar,btnAtualizar,btnCancelar);
            return controlador;
        }

        private void frmTelaCadastroFuncionario_Load(object sender, EventArgs e)
        {
            controladorTelaCadastroFuncionario().Load();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFuncionario().Inserir();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFuncionario().Salvar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFuncionario().Atualizar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            {
                if (btnInserir.Enabled.Equals(true))
                    this.Close();
                else
                    controladorTelaCadastroFuncionario().Load();
            }
        }
    }
}
