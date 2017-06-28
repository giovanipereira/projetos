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
    public partial class frmTelaConsultaPedido : Form
    {
        public frmTelaConsultaPedido()
        {
            InitializeComponent();
        }

        frmTelaCadastroPedido telaCadastroPedido;

        ControladorTelaConsultaPedido controladorTelaConsultaPedido()
        {
            ControladorTelaConsultaPedido controlador = new ControladorTelaConsultaPedido(dgvConsultaPedidos);
            return controlador;
        }

        private void frmTelaConsultaPedido_Load(object sender, EventArgs e)
        {
            controladorTelaConsultaPedido().Load();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void Atualizar()
        {
            if (dgvConsultaPedidos.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaPedidos.CurrentRow.Cells[0].Value.ToString());
                object[] dados = controladorTelaConsultaPedido().ObterDadosPedido(id);
                telaCadastroPedido = new frmTelaCadastroPedido((int)EnumOpcao.Atualizar);
                controladorTelaConsultaPedido().SalvarItensPedidoTemporariamente(id);
                telaCadastroPedido.txtCodigo.Text = dados[0].ToString();
                telaCadastroPedido.dtpData.Value = DateTime.Parse(dados[1].ToString());
                telaCadastroPedido.txtHorario.Text = dados[2].ToString();
                telaCadastroPedido.cboMesa.SelectedValue = dados[3].ToString();
                telaCadastroPedido.txtTotal.Text = dados[5].ToString();
                telaCadastroPedido.ShowDialog();
            }
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            frmTelaDetalhesPedido telaDetalhesPedido = new frmTelaDetalhesPedido();
            int id = int.Parse(dgvConsultaPedidos.CurrentRow.Cells[0].Value.ToString());
            object[] dados = controladorTelaConsultaPedido().ObterDadosPedido(id);
            telaDetalhesPedido.lblCodigo.Text = dados[0].ToString();
            telaDetalhesPedido.lblData.Text = dados[1].ToString().Substring(0,10);
            telaDetalhesPedido.lblHorario.Text = dados[2].ToString();
            telaDetalhesPedido.lblMesa.Text = dados[3].ToString();
            telaDetalhesPedido.lblTotal.Text = dados[5].ToString();
            controladorTelaConsultaPedido().ListarTodosItensPedido(id, telaDetalhesPedido.lbProdutos);
            telaDetalhesPedido.ShowDialog();
        }
    }
}
