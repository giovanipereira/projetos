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
        public frmTelaCadastroCardapio(int opcao)
        {
            InitializeComponent();
            this.opcao = opcao;
            if (opcao.Equals((int)EnumOpcao.Atualizar))
                controladorTelaCadastroCardapio().PreencherCombobox();
        }

        private int opcao;

        ControladorTelaConsultaProduto controladorTelaConsultaProduto = new ControladorTelaConsultaProduto();

        ControladorTelaCadastroCardapio controladorTelaCadastroCardapio()
        {
            ControladorTelaCadastroCardapio controlador = new ControladorTelaCadastroCardapio(txtCodigo,
            txtNome, txtPreco, txtDescricao, picFigura, btnEscolher, btnRemover,
            btnSelecionar, btnInserir, btnSalvar, btnAtualizar, btnCancelar, dgvListaProdutos,
            cboCategoria, btnRemoverItem, btnEditarItem);
            return controlador;
        }

        frmTelaConsultaProduto telaConsultaProduto;
        frmTelaCardapioItem telaCardapioItem;

        private void Editar()
        {
            int ordem = controladorTelaCadastroCardapio().ObterOrdemItem(int.Parse(dgvListaProdutos.CurrentRow.Cells[0].Value.ToString()));
            if (ordem != 0)
            {
                telaCardapioItem = new frmTelaCardapioItem((int)EnumOpcao.Atualizar);
                object[] dados = controladorTelaCadastroCardapio().ObterDadosItem(int.Parse(dgvListaProdutos.CurrentRow.Cells[0].Value.ToString()));
                telaCardapioItem.txtCodigoProduto.Text = dados[0].ToString();
                telaCardapioItem.txtNomeProduto.Text = dados[1].ToString();
                telaCardapioItem.cboUnidadeProduto.SelectedValue = dados[2].ToString();
                telaCardapioItem.txtQuantidadeProduto.Text = dados[3].ToString().Replace(",", ".");
                telaCardapioItem.ShowDialog();
                controladorTelaCadastroCardapio().ListarProdutos();
            }
            else
            {
                controladorTelaCadastroCardapio().ListarProdutos();
            }
        }

        private void frmTelaCadastroCardapio_Load(object sender, EventArgs e)
        {
            if (opcao.Equals((int)EnumOpcao.Cadastro))
                controladorTelaCadastroCardapio().Load((int)EnumOpcao.Cadastro);
            else if (opcao.Equals((int)EnumOpcao.Atualizar))
                controladorTelaCadastroCardapio().Load((int)EnumOpcao.Atualizar);
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
            telaConsultaProduto = new frmTelaConsultaProduto((int)EnumOpcao.Adicionar);
            telaConsultaProduto.ShowDialog();
            controladorTelaCadastroCardapio().ListarProdutos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Enabled.Equals(false))
            {
                controladorTelaCadastroCardapio().RemoverTodosItensTemporarios();
                this.Close();
            }
                
            else if (opcao.Equals((int)EnumOpcao.Atualizar))
            {
                controladorTelaCadastroCardapio().RemoverTodosItensTemporarios();
                this.Close();
            }
            else
            {
                controladorTelaCadastroCardapio().RemoverTodosItensTemporarios();
                controladorTelaCadastroCardapio().Load((int)EnumOpcao.Cadastro);
            }
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

        private void btnEditarItem_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void dgvListaProdutos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            controladorTelaCadastroCardapio().HabilitarBotaoItem();
        }

        private void frmTelaCadastroCardapio_FormClosing(object sender, FormClosingEventArgs e)
        {
            controladorTelaCadastroCardapio().RemoverTodosItensTemporarios();
        }

        private void dgvListaProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Editar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroCardapio().Atualizar(this);
        }
    }
}
