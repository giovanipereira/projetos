using ProjetoControleEstoque.Controller.controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.View.layout
{
    public partial class frmTelaPedidoItem : Form
    {
        public frmTelaPedidoItem(int opcao)
        {
            InitializeComponent();
            this.opcao = opcao;
        }

        private int opcao;

        ControladorTelaPedidoItem controladorTelaPedidoItem()
        {
            ControladorTelaPedidoItem controlador = new ControladorTelaPedidoItem(txtCodigo, txtNome, txtPreco, picFigura,
                nudQuantidade, btnAdicionar, btnAtualizar, btnCancelar);
            return controlador;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controladorTelaPedidoItem().Salvar(this);
        }

        private void frmTelaPedidoItem_Load(object sender, EventArgs e)
        {
            if (opcao.Equals((int)EnumOpcao.Cadastro))
                controladorTelaPedidoItem().Load((int)EnumOpcao.Cadastro);
            else if (opcao.Equals((int)EnumOpcao.Atualizar))
                controladorTelaPedidoItem().Load((int)EnumOpcao.Atualizar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            controladorTelaPedidoItem().Atualizar(this);
        }
    }
}
