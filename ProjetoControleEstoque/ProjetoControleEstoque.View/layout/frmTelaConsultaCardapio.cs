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
    public partial class frmTelaConsultaCardapio : Form
    {
        public frmTelaConsultaCardapio(int opcao)
        {
            InitializeComponent();
            this.opcao = opcao;
        }

        public int opcao;

        frmTelaCadastroCardapio telaCadastroCardapio;

        ControladorTelaConsultaCardapio controladorTelaConsultaCardapio()
        {
            ControladorTelaConsultaCardapio controlador = new ControladorTelaConsultaCardapio(cboConsultarPor, txtValor,
                btnConsultar, btnExcluir, btnBuscarTodos, dgvConsultaCardapio);
            return controlador;
        }

        private void Atualizar()
        {
            if (dgvConsultaCardapio.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaCardapio.CurrentRow.Cells[0].Value.ToString());
                object[] dados = controladorTelaConsultaCardapio().ObterDadosCardapio(id);
                telaCadastroCardapio = new frmTelaCadastroCardapio((int)EnumOpcao.Atualizar);
                controladorTelaConsultaCardapio().SalvarItensCardapiosTemporariamente(id);
                telaCadastroCardapio.txtCodigo.Text = dados[0].ToString();
                telaCadastroCardapio.txtNome.Text = dados[1].ToString();
                telaCadastroCardapio.txtPreco.Text = dados[2].ToString().Replace(",",".");
                telaCadastroCardapio.cboCategoria.SelectedValue = dados[3].ToString();
                telaCadastroCardapio.picFigura.ImageLocation = dados[4].ToString();
                telaCadastroCardapio.txtDescricao.Text = dados[5].ToString();
                telaCadastroCardapio.ShowDialog();
                controladorTelaConsultaCardapio().ConsultarPorId(id);
            }
        }

        private void Adicionar()
        {
            if (dgvConsultaCardapio.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaCardapio.CurrentRow.Cells[0].Value.ToString());
                object[] dados = controladorTelaConsultaCardapio().ObterDadosCardapio(id);
                frmTelaPedidoItem tela = new frmTelaPedidoItem((int)EnumOpcao.Cadastro);
                tela.txtCodigo.Text = dados[0].ToString();
                tela.txtNome.Text = dados[1].ToString();
                tela.txtPreco.Text = dados[2].ToString();
                tela.picFigura.ImageLocation = dados[4].ToString();
                tela.ShowDialog();
                this.Close();
            }
        }

        private void frmTelaConsultaCardapio_Load(object sender, EventArgs e)
        {
            if (opcao.Equals(0))
            {
                controladorTelaConsultaCardapio().Load();
                btnAdicionar.Enabled = false;
            }
            else if (opcao.Equals((int)EnumOpcao.Adicionar))
            {
                controladorTelaConsultaCardapio().Load();
                btnExcluir.Enabled = false;
                btnAtualizar.Enabled = false;
            }

        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaCardapio().BuscarTodos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaCardapio().Consultar();
        }

        private void cboConsultarPor_TextChanged(object sender, EventArgs e)
        {
            controladorTelaConsultaCardapio().ConsultarPorTextChanged();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaConsultaCardapio().ValorKeyPress(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaCardapio().Remover();
        }

        private void dgvConsultaCardapio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (opcao.Equals((int)EnumOpcao.Adicionar))
            {
                Adicionar();
            }
            else
            {
                Atualizar();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }
    }
}
