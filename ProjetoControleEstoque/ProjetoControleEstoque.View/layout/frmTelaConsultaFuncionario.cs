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
    public partial class frmTelaConsultaFuncionario : Form
    {
        public frmTelaConsultaFuncionario()
        {
            InitializeComponent();
        }

        frmTelaCadastroFuncionario telaCadastroFuncionario;

        ControladorTelaConsultaFuncionario controladorTelaConsultaFuncionario()
        {
            ControladorTelaConsultaFuncionario controlador = new ControladorTelaConsultaFuncionario(cboConsultarPor, txtValor,
                btnConsultar, btnExcluir, dgvConsultaFuncionarios);
            return controlador;
        }

        private void Atualizar()
        {
            if (dgvConsultaFuncionarios.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaFuncionarios.CurrentRow.Cells[0].Value.ToString());
                object[] dados = controladorTelaConsultaFuncionario().ObterDadosFuncionario(id);
                telaCadastroFuncionario = new frmTelaCadastroFuncionario((int)EnumOpcao.Atualizar);
                telaCadastroFuncionario.txtCodigo.Text = dados[0].ToString();
                telaCadastroFuncionario.txtNome.Text = dados[1].ToString();
                telaCadastroFuncionario.mskCpf.Text = dados[2].ToString();
                telaCadastroFuncionario.txtEmail.Text = dados[3].ToString();
                telaCadastroFuncionario.mskTelefone.Text = dados[4].ToString();
                telaCadastroFuncionario.cboCargo.SelectedValue = dados[5].ToString();
                telaCadastroFuncionario.cboNivelAcesso.SelectedValue = dados[6].ToString();
                telaCadastroFuncionario.id_usuario = int.Parse(dados[7].ToString());
                telaCadastroFuncionario.txtUsuario.Text = dados[8].ToString();
                telaCadastroFuncionario.txtSenha.Text = dados[9].ToString();
                telaCadastroFuncionario.txtConfirmarSenha.Text = dados[9].ToString();
                telaCadastroFuncionario.controladorTelaCadastroFuncionario().Load((int)EnumOpcao.Atualizar);
                telaCadastroFuncionario.ShowDialog();
                controladorTelaConsultaFuncionario().ConsultarPorId(int.Parse(dados[0].ToString()));
            }
        }

        private void frmTelaConsultaFuncionario_Load(object sender, EventArgs e)
        {
            controladorTelaConsultaFuncionario().Load();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaFuncionario().Consultar();
        }

        private void cboConsultarPor_TextChanged(object sender, EventArgs e)
        {
            controladorTelaConsultaFuncionario().ConsultarPorTextChanged();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            controladorTelaConsultaFuncionario().ValorKeyPress(sender, e);
        }

        private void dgvConsultaFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Atualizar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controladorTelaConsultaFuncionario().Remover();
        }
    }
}
