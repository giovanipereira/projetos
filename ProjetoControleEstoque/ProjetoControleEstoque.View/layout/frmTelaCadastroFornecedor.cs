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
    public partial class frmTelaCadastroFornecedor : Form
    {
        public frmTelaCadastroFornecedor()
        {
            InitializeComponent();
        }

        ControladorTelaCadastroFornecedor controladorTelaCadastroFornecedor()
        {
            ControladorTelaCadastroFornecedor controlador = new ControladorTelaCadastroFornecedor(txtCodigo,
                txtNome, txtEmail, txtEndereco, txtComplemento, txtBairro, txtCidade, cboUf, mskCnpj, mskTelefone,
                mskCep, btnInserir, btnSalvar, btnAtualizar, btnCancelar);
            return controlador;
        }

        private void frmTelaCadastroFornecedor_Load(object sender, EventArgs e)
        {
            controladorTelaCadastroFornecedor().Load();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFornecedor().Inserir();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFornecedor().Salvar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFornecedor().Atualizar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnInserir.Enabled.Equals(true))
                this.Close();
            else
                controladorTelaCadastroFornecedor().Load();
        }
    }
}
