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
    public partial class frmTelaCadastroPedido : Form
    {
        public frmTelaCadastroPedido(int opcao)
        {
            InitializeComponent();
            this.opcao = opcao;
        }

        int opcao;

        frmTelaConsultaCardapio telaConsultaCardapio;
        frmTelaPedidoItem telaPedidoItem;

        ControladorTelaCadastroPedido controladorTelaCadastroPedido()
        {
            ControladorTelaCadastroPedido controlador = new ControladorTelaCadastroPedido(txtCodigo, txtHorario,
                txtTotal, cboMesa, btnRemoverItem, btnEditarItem, btnSelecionar, dgvListaCardapios, dtpData, btnInserir,
                btnSalvar, btnAtualizar, btnCancelar);
            return controlador;
        }

        private void Editar()
        {
            int ordem = controladorTelaCadastroPedido().ObterOrdemItem(int.Parse(dgvListaCardapios.CurrentRow.Cells[0].Value.ToString()));
            if (ordem != 0)
            {
                telaPedidoItem = new frmTelaPedidoItem((int)EnumOpcao.Atualizar);
                object[] dados = controladorTelaCadastroPedido().ObterDadosItem(int.Parse(dgvListaCardapios.CurrentRow.Cells[0].Value.ToString()));
                telaPedidoItem.txtCodigo.Text = dados[0].ToString();
                telaPedidoItem.txtNome.Text = dados[1].ToString();
                telaPedidoItem.txtPreco.Text = dados[2].ToString();
                telaPedidoItem.picFigura.ImageLocation = dados[3].ToString();
                telaPedidoItem.nudQuantidade.Value = (int)dados[4];
                telaPedidoItem.ShowDialog();
                controladorTelaCadastroPedido().ListarProdutos();
            }
            else
            {
                controladorTelaCadastroPedido().ListarProdutos();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroPedido().Inserir();
            txtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        private void frmTelaCadastroPedido_Load(object sender, EventArgs e)
        {
            if (opcao.Equals((int)EnumOpcao.Cadastro))
                controladorTelaCadastroPedido().Load((int)EnumOpcao.Cadastro);
            else if (opcao.Equals((int)EnumOpcao.Atualizar))
                controladorTelaCadastroPedido().Load((int)EnumOpcao.Atualizar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Enabled.Equals(false))
            {
                controladorTelaCadastroPedido().RemoverTodosItensTemporarios();
                this.Close();
            }

            else if (opcao.Equals((int)EnumOpcao.Atualizar))
            {
                controladorTelaCadastroPedido().RemoverTodosItensTemporarios();
                this.Close();
            }
            else
            {
                controladorTelaCadastroPedido().RemoverTodosItensTemporarios();
                controladorTelaCadastroPedido().Load((int)EnumOpcao.Cadastro);
                timer.Stop();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            txtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            telaConsultaCardapio = new frmTelaConsultaCardapio((int)EnumOpcao.Adicionar);
            telaConsultaCardapio.ShowDialog();
            controladorTelaCadastroPedido().ListarProdutos();
        }

        private void frmTelaCadastroPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            controladorTelaCadastroPedido().RemoverTodosItensTemporarios();
        }

        private void dgvListaCardapios_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            txtTotal.Text = controladorTelaCadastroPedido().CalcularValorTotal().Replace(",", ".");
            controladorTelaCadastroPedido().HabilitarBotaoItem();
        }

        private void dgvListaCardapios_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtTotal.Text = controladorTelaCadastroPedido().CalcularValorTotal();
            controladorTelaCadastroPedido().HabilitarBotaoItem();
        }

        private void btnEditarItem_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroPedido().RemoverItem();
        }

        private void dgvListaCardapios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Editar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroPedido().Salvar();
        }
    }
}
