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
    public partial class frmTelaConsultaFornecedor : Form
    {
        public frmTelaConsultaFornecedor()
        {
            InitializeComponent();
        }

        frmTelaCadastroFornecedor telaCadastroFornecedor;

        ControladorTelaConsultaFornecedor controladorTelaConsultaFornecedor()
        {
            ControladorTelaConsultaFornecedor controlador = new ControladorTelaConsultaFornecedor(cboConsultarPor, txtValor,
                btnConsultar, btnExcluir, dgvConsultaFornecedores);
            return controlador;
        }

        private void Atualizar()
        {
            if (dgvConsultaFornecedores.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaFornecedores.CurrentRow.Cells[0].Value.ToString());
                object[] dados = controladorTelaConsultaFornecedor().ObterDadosFornecedor(id);
                telaCadastroFornecedor = new frmTelaCadastroFornecedor((int)EnumOpcao.Atualizar);
                telaCadastroFornecedor.txtCodigo.Text = dados[0].ToString();
                telaCadastroFornecedor.txtNome.Text = dados[1].ToString();
                telaCadastroFornecedor.mskCnpj.Text = dados[2].ToString();
                telaCadastroFornecedor.txtEndereco.Text = dados[3].ToString();
                telaCadastroFornecedor.txtComplemento.Text = dados[4].ToString();
                telaCadastroFornecedor.txtBairro.Text = dados[5].ToString();
                telaCadastroFornecedor.txtCidade.Text = dados[6].ToString();
                telaCadastroFornecedor.mskCep.Text = dados[8].ToString();
                telaCadastroFornecedor.txtEmail.Text = dados[9].ToString();
                telaCadastroFornecedor.mskTelefone.Text = dados[10].ToString();
                telaCadastroFornecedor.cboUf.SelectedValue = dados[11].ToString();
                telaCadastroFornecedor.controladorTelaCadastroFornecedor().Load((int)EnumOpcao.Atualizar);
                telaCadastroFornecedor.ShowDialog();
                controladorTelaConsultaFornecedor().ConsultarPorId(int.Parse(dados[0].ToString()));
            }
        }


        private void frmTelaConsultaFornecedor_Load(object sender, EventArgs e)
        {
            controladorTelaConsultaFornecedor().Load();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaFornecedor().Consultar();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaConsultaFornecedor().ValorKeyPress(sender, e);
        }

        private void cboConsultarPor_TextChanged(object sender, EventArgs e)
        {
            controladorTelaConsultaFornecedor().ConsultarPorTextChanged(sender, e);
        }

        private void dgvConsultaFornecedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Atualizar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaFornecedor().Remover();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaFornecedor().BuscarTodos();
        }
    }
}
