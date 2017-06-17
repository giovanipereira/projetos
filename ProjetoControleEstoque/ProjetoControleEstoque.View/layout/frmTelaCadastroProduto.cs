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
    public partial class frmTelaCadastroProduto : Form
    {
        public frmTelaCadastroProduto(int opcao)
        {
            InitializeComponent();
            this.opcao = opcao;
            if (opcao.Equals((int)EnumOpcao.Atualizar))
                controladorTelaCadastroProduto().PreencherCombobox();
        }

        private int opcao;

        public ControladorTelaCadastroProduto controladorTelaCadastroProduto()
        {
            ControladorTelaCadastroProduto controlador = new ControladorTelaCadastroProduto(txtCodigo,
                txtNome, txtValorUnitario, txtQuantidade, txtDescricao, cboFornecedor, cboUnidade, cboSubcategoria,
                cboCategoria, nudQtdEstoque, nudQtdMinima, nudQtdMaxima, dtpDataValidade, btnInserir, btnSalvar,
                btnAtualizar, btnCancelar);
            return controlador;
        }

        private void frmTelaCadastroProduto_Load(object sender, EventArgs e)
        {
            if (opcao.Equals((int)EnumOpcao.Cadastro))
                controladorTelaCadastroProduto().Load((int)EnumOpcao.Cadastro);
            else if (opcao.Equals((int)EnumOpcao.Atualizar))
                controladorTelaCadastroProduto().Load((int)EnumOpcao.Atualizar);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().Inserir();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().Salvar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().Atualizar(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Enabled.Equals(false))
                this.Close();
            else if (opcao.Equals((int)EnumOpcao.Atualizar))
                this.Close();
            else
                controladorTelaCadastroProduto().Load((int)EnumOpcao.Cadastro);
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaCadastroProduto().QuantidadeKeyPress(sender, e);
        }

        private void cboUnidade_TextChanged(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().UnidadeTextChanged();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().QuantidadeLeave(sender, e);
        }

        private void txtValorUnitario_Leave(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().ValorUnitarioLeave();
        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaCadastroProduto().ValorUnitarioKeyPress(sender, e);
        }

        private void cboCategoria_TextChanged(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().CategoriaTextChanged();
        }
    }
}
