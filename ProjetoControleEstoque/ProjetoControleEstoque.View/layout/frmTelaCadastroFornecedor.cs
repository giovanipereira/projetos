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
    public partial class frmTelaCadastroFornecedor : Form
    {
        public frmTelaCadastroFornecedor()
        {
            InitializeComponent();
        }

        ControladorTelaCadastroFornecedor controladorTelaCadastroFornecedor()
        {
            ControladorTelaCadastroFornecedor controlador = new ControladorTelaCadastroFornecedor(txtCodigo,
                txtNome, txtEmail, txtEndereco, txtComplemento, txtBairro, txtCidade, cboUf, mskCnpj, mskTelefone,
                mskCep, btnInserir, btnSalvar, btnAtualizar, btnCancelar);
            return controlador;
        }

        private void frmTelaCadastroFornecedor_Load(object sender, EventArgs e)
        {
            controladorTelaCadastroFornecedor().Load();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFornecedor().Inserir();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFornecedor().Salvar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroFornecedor().Atualizar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboUf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComplemento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void mskTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskCnpj_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
