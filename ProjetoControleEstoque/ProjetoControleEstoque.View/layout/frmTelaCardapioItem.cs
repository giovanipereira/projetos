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
    public partial class frmTelaCardapioItem : Form
    {
        public frmTelaCardapioItem(int opcao)
        {
            InitializeComponent();
            this.opcao = opcao;
            controladorTelaCardapioItem().PreencherUnidade();
        }

        int opcao;

        public frmTelaCadastroCardapio telaCadastroCardapio;

        private ControladorTelaCardapioItem controladorTelaCardapioItem()
         {
             ControladorTelaCardapioItem controlador = new ControladorTelaCardapioItem(txtCodigoProduto, txtNomeProduto,
                 txtQuantidadeProduto, cboUnidadeProduto, btnAdicionar, btnAtualizar, btnCancelar);
             return controlador;
         }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controladorTelaCardapioItem().Salvar(this);
        }

        private void frmTelaCardapioItem_Load(object sender, EventArgs e)
        {
            if (opcao.Equals((int)EnumOpcao.Cadastro))
                controladorTelaCardapioItem().Load((int)EnumOpcao.Cadastro);
            else if (opcao.Equals((int)EnumOpcao.Atualizar))
                controladorTelaCardapioItem().Load((int)EnumOpcao.Atualizar);
        }

        private void txtQuantidadeProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaCardapioItem().QuantidadeProdutoKeyPress(sender,e);
        }

        private void txtQuantidadeProduto_Leave(object sender, EventArgs e)
        {
            controladorTelaCardapioItem().QuantidadeProdutoLeave();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            controladorTelaCardapioItem().Atualizar(this);
        }
    }
}
