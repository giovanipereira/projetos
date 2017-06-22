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

        ControladorTelaConsultaProduto controladorTelaConsultaProduto = new ControladorTelaConsultaProduto();

        ControladorTelaCadastroCardapio controladorTelaCadastroCardapio()
        {
            ControladorTelaCadastroCardapio controlador = new ControladorTelaCadastroCardapio(txtCodigo,
            txtNome, txtPreco, txtDescricao, picFigura, btnEscolher, btnRemover,
            btnSelecionar, btnInserir, btnSalvar, btnAtualizar, btnCancelar, dgvListaProdutos,
            cboCategoria, btnRemoverItem, btnEditarItem);
            return controlador;
        }
        public Produto produto = new Produto();
        public List<ItemCardapio> listaItens = new List<ItemCardapio>();
        public frmTelaConsultaProduto telaConsultaProduto;
        public frmTelaCardapioItem telaCardapioItem;
        public ItemCardapio itemCardapio = new ItemCardapio();

        public void MostrarDGV()
        {
            listaItens.Add(itemCardapio);
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

        public Produto ObterProduto(Produto produto)
        {
            this.produto = produto;
            return produto;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            telaConsultaProduto = new frmTelaConsultaProduto();
            telaConsultaProduto.ShowDialog();
            telaCardapioItem = new frmTelaCardapioItem((int)EnumOpcao.Cadastro);
            telaCardapioItem.telaCadastroCardapio = this;
            telaCardapioItem.txtCodigoProduto.Text = produto.Id.ToString();
            telaCardapioItem.txtNomeProduto.Text = produto.Nome;
            telaCardapioItem.cboUnidadeProduto.SelectedValue = produto.Id_unidade.ToString();
            telaCardapioItem.ShowDialog();
            produto.Quantidade = telaCardapioItem.txtQuantidadeProduto.Text;
            itemCardapio = new ItemCardapio();
            itemCardapio.Id_produto = produto.Id;
            itemCardapio.Nome = produto.Nome;
            itemCardapio.Quantidade = produto.Quantidade;
            itemCardapio.Unidade = telaCardapioItem.cboUnidadeProduto.Text;
            listaItens.Add(itemCardapio);
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
