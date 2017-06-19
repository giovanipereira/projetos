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
using ProjetoControleEstoque.Model.dominio;

namespace ProjetoControleEstoque.View.layout
{
    public partial class frmTelaCadastroCardapio : Form
    {
        public frmTelaCadastroCardapio()
        {
            InitializeComponent();
        }

        public object[] dados;
        public string quantidade;

        ControladorTelaCadastroCardapio controladorTelaCadastroCardapio()
        {
            ControladorTelaCadastroCardapio controlador = new ControladorTelaCadastroCardapio(txtCodigo,
            txtNome, txtPreco, txtDescricao, picFigura, btnEscolher, btnRemover,
            btnSelecionar, btnInserir, btnSalvar, btnAtualizar, btnCancelar, dgvListaProdutos,
            cboCategoria, btnRemoverItem, btnEditarItem);
            return controlador;
        }

        List<ItemCardapio> listaItens = new List<ItemCardapio>();
        frmTelaConsultaProduto telaConsultaProduto;
        frmTelaCardapioItem telaCardapioItem;

        public void ObterQuantidade(string quantidade)
        {
            
        }

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
            telaConsultaProduto.telaCadastroCardapio = this;
            telaConsultaProduto.ShowDialog();
            telaCardapioItem = new frmTelaCardapioItem();
            telaCardapioItem.telaCadastroCardapio = this;
            telaCardapioItem.txtCodigoProduto.Text = dados[0].ToString();
            telaCardapioItem.txtNomeProduto.Text = dados[1].ToString();
            telaCardapioItem.cboUnidadeProduto.Text = dados[11].ToString();
            telaCardapioItem.ShowDialog();
            ItemCardapio item = new ItemCardapio();
            item.Id_produto = (int)dados[0];
            item.Nome = dados[1].ToString();
            item.Unidade = dados[11].ToString();
            item.Quantidade = quantidade;
            listaItens.Add(item);
            dgvListaProdutos.DataSource = listaItens;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            {
                if (btnInserir.Enabled.Equals(true))
                    this.Close();
                else
                    controladorTelaCadastroCardapio().Load();
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
    }
}
