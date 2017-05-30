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
    public partial class frmTelaCadastroCardapio : Form
    {
        public frmTelaCadastroCardapio()
        {
            InitializeComponent();
        }

        ControladorTelaCadastroCardapio controladorTelaCadastroCardapio()
        {
            ControladorTelaCadastroCardapio controlador = new ControladorTelaCadastroCardapio(txtCodigo,
            txtNome, txtPreco, txtDescricao, picFigura, btnEscolher, btnRemover,
            btnSelecionar, btnInserir, btnSalvar, btnAtualizar, btnCancelar, dgvListaProdutos,
            cboCategoria, btnRemoverItem, btnEditarItem);
            return controlador;
        }

        frmTelaConsultaProduto telaConsultaProduto;

        private void frmTelaCadastroCardapio_Load(object sender, EventArgs e)
        {
            controladorTelaCadastroCardapio().Load();
        }

        private void btnEscolher_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroCardapio().EscolherFigura();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroCardapio().RemoverFigura();
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroCardapio().RemoverItem();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroCardapio().Inserir();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroCardapio().Salvar();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            telaConsultaProduto = new frmTelaConsultaProduto();
            controladorTelaCadastroCardapio().SelecionarProduto(telaConsultaProduto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            controladorTelaCadastroCardapio().PrecoLeave();
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaCadastroCardapio().PrecoKeyPress(sender, e);
        }

        private void dgvListaProdutos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            controladorTelaCadastroCardapio().HabilitarBotaoItem();
        }
    }
}
