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
        public frmTelaCadastroPedido()
        {
            InitializeComponent();
        }

        ControladorTelaCadastroPedido controladorTelaCadastroPedido()
        {
            ControladorTelaCadastroPedido controlador = new ControladorTelaCadastroPedido(txtNumeroPedido, txtHorario,
                txtTotal, cboMesa, btnRemoverItem, btnEditarItem, btnAdicionarItem, dgvConsulta, dtpData, btnInserir, btnSalvar,
                btnAtualizar, btnCancelar);
            return controlador;
        }

        private void frmTelaCadastroPedido_Load(object sender, EventArgs e)
        {
            controladorTelaCadastroPedido().Load();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroPedido().Inserir();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroPedido().Salvar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvConsulta_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            controladorTelaCadastroPedido().HabilitarBotaoItem();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            //controladorTelaCadastroPedido().Add();
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            controladorTelaCadastroPedido().RemoverItem();
        }
    }
}
