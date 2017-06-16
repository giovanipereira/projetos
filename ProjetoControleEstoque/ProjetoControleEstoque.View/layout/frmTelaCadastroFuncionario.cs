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
        public frmTelaCadastroFuncionario(int opcao)
        {
            InitializeComponent();
            this.opcao = opcao;
        }

        private int opcao;

        public ControladorTelaCadastroFuncionario controladorTelaCadastroFuncionario()
        {
            ControladorTelaCadastroFuncionario controlador = new ControladorTelaCadastroFuncionario(txtCodigo,
                txtNome, txtEmail, txtUsuario, txtSenha, txtConfirmarSenha, cboCargo, cboNivelAcesso, mskCpf,
                mskTelefone, btnInserir, btnSalvar, btnAtualizar, btnCancelar);
            return controlador;
        }

        private void frmTelaCadastroFuncionario_Load(object sender, EventArgs e)
        {
            if (opcao.Equals((int)EnumOpcao.Cadastro))
                controladorTelaCadastroFuncionario().Load((int)EnumOpcao.Cadastro);

            if (opcao.Equals((int)EnumOpcao.Atualizar))
                controladorTelaCadastroFuncionario().Load((int)EnumOpcao.Atualizar);
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
                if (btnSalvar.Enabled.Equals(false))
                    this.Close();
                else if (opcao.Equals((int)EnumOpcao.Atualizar))
                    this.Close();
                else
                controladorTelaCadastroFuncionario().Load((int)EnumOpcao.Cadastro);
            }
        }
    }

    public enum EnumOpcao
    {
        Cadastro = 1,
        Atualizar = 3
    }
}
