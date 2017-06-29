using ProjetoControleEstoque.Controller.controlador;
using ProjetoControleEstoque.Model.dominio;
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
    public partial class frmTelaConsultaProduto : Form
    {
        public frmTelaConsultaProduto(int opcao)
        {
            InitializeComponent();
            this.opcao = opcao;
        }

        frmTelaCadastroProduto telaCadastroProduto;

        public int opcao;

        ControladorTelaConsultaProduto controladorTelaConsultaProduto()
        {
            ControladorTelaConsultaProduto controlador = new ControladorTelaConsultaProduto(cboConsultarPor, txtValor,
                btnConsultar, btnAdicionar, btnExcluir, dgvConsultaProdutos);
            return controlador;
        }

        private void Atualizar()
        {
            if (dgvConsultaProdutos.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaProdutos.CurrentRow.Cells[0].Value.ToString());
                object[] dados = controladorTelaConsultaProduto().ObterDadosProduto(id);
                telaCadastroProduto = new frmTelaCadastroProduto((int)EnumOpcao.Atualizar, (int)dados[9]);
                telaCadastroProduto.txtCodigo.Text = dados[0].ToString();
                telaCadastroProduto.txtNome.Text = dados[1].ToString();
                telaCadastroProduto.txtValorUnitario.Text = dados[2].ToString().Replace(",", ".");
                if ((int)dados[3] < 0)
                    telaCadastroProduto.nudQtdEstoque.Value = 1;
                else
                    telaCadastroProduto.nudQtdEstoque.Value = (int)dados[3];
                telaCadastroProduto.nudQtdMinima.Value = (int)dados[4];
                telaCadastroProduto.nudQtdMaxima.Value = (int)dados[5];
                telaCadastroProduto.txtQuantidade.Text = dados[6].ToString().Replace(",", ".");
                telaCadastroProduto.dtpDataValidade.Value = (DateTime)dados[7];
                telaCadastroProduto.txtDescricao.Text = dados[8].ToString();
                telaCadastroProduto.cboSubcategoria.SelectedValue = dados[9].ToString();
                telaCadastroProduto.cboFornecedor.SelectedValue = dados[10].ToString();
                telaCadastroProduto.cboUnidade.SelectedValue = dados[11].ToString();
                telaCadastroProduto.cboCategoria.SelectedValue = dados[12].ToString();
                telaCadastroProduto.controladorTelaCadastroProduto().Load((int)EnumOpcao.Atualizar, (int)dados[9]);
                telaCadastroProduto.ShowDialog();
                controladorTelaConsultaProduto().ConsultarPorId(int.Parse(dados[0].ToString()));
            }
        }

        private void frmTelaConsultaProduto_Load(object sender, EventArgs e)
        {
            if (opcao.Equals(0))
            {
                controladorTelaConsultaProduto().Load();
                btnAdicionar.Enabled = false;
            }
            else if (opcao.Equals((int)EnumOpcao.Adicionar))
            {
                controladorTelaConsultaProduto().Load();
                btnExcluir.Enabled = false;
                btnAtualizar.Enabled = false;
            }
        }

        private void cboConsultarPor_TextChanged(object sender, EventArgs e)
        {
            controladorTelaConsultaProduto().ConsultarPorTextChanged();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaProduto().Consultar();
        }

        private void dgvConsultaProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaProduto().Remover();
        }

        private void Adicionar()
        {
            if (dgvConsultaProdutos.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaProdutos.CurrentRow.Cells[0].Value.ToString());
                object[] dados = controladorTelaConsultaProduto().ObterDadosProduto(id);
                frmTelaCardapioItem tela = new frmTelaCardapioItem((int)EnumOpcao.Cadastro);
                tela.txtCodigoProduto.Text = dados[0].ToString();
                tela.txtNomeProduto.Text = dados[1].ToString();
                tela.cboUnidadeProduto.SelectedValue = dados[11].ToString();
                tela.ShowDialog();
                this.Close();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaProduto().BuscarTodos();
        }
    }
}
