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
        public frmTelaCadastroProduto()
        {
            InitializeComponent();
        }

        ControladorTelaCadastroProduto controladorTelaCadastroProduto()
        {
            ControladorTelaCadastroProduto controlador = new ControladorTelaCadastroProduto(txtCodigo,
                txtNome, txtValorUnitario, txtPorcao, txtDescricao, cboFornecedor, cboUnidade, cboSubcategoria,
                cboCategoria, nudQtdFornecidas, nudQtdEstoque, nudQtdMinima, nudQtdMaxima, dtpDataValidade, btnInserir, btnSalvar,
                btnAtualizar, btnCancelar);
            return controlador;
        }

        private void frmTelaCadastroProduto_Load(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().Load();
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
            controladorTelaCadastroProduto().Atualizar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaCadastroProduto().ValorUnitarioKeyPress(sender, e);
        }

        private void txtPrecoCompra_Leave(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().ValorUnitarioLeave();
        }

        private void txtPorcao_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaCadastroProduto().PorcaoKeyPress(sender, e);
        }

        private void cboCategoria_TextChanged(object sender, EventArgs e)
        {
        }

        private void cboCategoria_Leave(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().CategoriaLeave();
        }

        private void nudQtdFornecidas_Leave(object sender, EventArgs e)
        {
            nudQtdEstoque.Value = nudQtdFornecidas.Value;
        }

        private void cboUnidade_Leave(object sender, EventArgs e)
        {
            controladorTelaCadastroProduto().UnidadeLeave();
        }
    }
}
