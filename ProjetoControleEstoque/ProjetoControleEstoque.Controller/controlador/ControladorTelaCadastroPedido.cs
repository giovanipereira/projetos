using ProjetoControleEstoque.Controller.utility;
using ProjetoControleEstoque.Controller.validacao;
using ProjetoControleEstoque.Model.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCadastroPedido : ControladorBase
    {
        #region Declaration
        private TextBox txtNumeroPedido, txtHorario, txtTotal; 
        private ComboBox cboMesa;
        private Button btnRemoverItem,btnEditarItem,btnAdicionarItem;
        private DataGridView dgvConsulta;
        private DateTimePicker dtpData;
        List<Pedido> a = new List<Pedido>();
        ValidacaoPedido validacao;

        #endregion

        #region Constructors
        public ControladorTelaCadastroPedido()
        {

        }

        public ControladorTelaCadastroPedido(TextBox txtNumeroPedido, TextBox txtHorario,TextBox txtTotal,
            ComboBox cboMesa, Button btnRemoverItem, Button btnEditarItem, Button btnAdicionarItem, DataGridView dgvConsulta,
            DateTimePicker dtpData, Button btnInserir,Button btnSalvar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtNumeroPedido = txtNumeroPedido;
            this.txtHorario = txtHorario;
            this.txtTotal = txtTotal;
            this.cboMesa = cboMesa;
            this.btnRemoverItem = btnRemoverItem;
            this.btnEditarItem = btnEditarItem;
            this.btnAdicionarItem = btnAdicionarItem;
            this.dgvConsulta = dgvConsulta;
            this.dtpData = dtpData;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnCancelar = btnCancelar;
            this.btnAtualizar = btnAtualizar;
            AdicionarListaControles();
        }

        #endregion

        #region Public Methods
        public void HabilitarBotaoItem()
        {
            if (dgvConsulta.Rows.Count > 0)
            {
                btnEditarItem.Enabled = true;
                btnRemoverItem.Enabled = true;
            }
            else
            {
                btnEditarItem.Enabled = false;
                btnRemoverItem.Enabled = false;
            }
        }

        public void RemoverItem()
        {
            if (dgvConsulta.Rows.Count > 0)
            {
                if (Mensagem.MensagemQuestao("Tem certeza que deseja remover esse item?")){
                    a.RemoveAll(p => p.Id == int.Parse((dgvConsulta.CurrentRow.Cells[0].Value.ToString())));
                    dgvConsulta.DataSource = a;
                }
                
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Abstracts Methods

        public override void AdicionarListaControles()
        {
            listaControles.Add(txtNumeroPedido);
            listaControles.Add(txtHorario);
            listaControles.Add(cboMesa);
            listaControles.Add(dtpData);
            listaControles.Add(dgvConsulta);
            listaControles.Add(btnRemoverItem);
            listaControles.Add(btnAdicionarItem);
            listaControles.Add(btnEditarItem);
            listaControles.Add(txtTotal);
            validacao = new ValidacaoPedido(listaControles);
        }

        public override void HabilitarTodosCampos(bool enable)
        {
            validacao.EnableControle(enable);
            txtNumeroPedido.Enabled = false;
            txtHorario.Enabled = false;
            txtTotal.Enabled = false;
            dtpData.Enabled = false;
            btnRemoverItem.Enabled = false;
            btnEditarItem.Enabled = false;
        }

        public override void LimparCampos()
        {
            validacao.LimparControles();
        }
        #endregion

        #region Event Functions

        public void Load()
        {
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Salvar()
        {
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Inserir()
        {
            OperationMode((int)EnumOperationMode.Inserir);
            Add();
        }

        public void Atualizar()
        {
            OperationMode((int)EnumOperationMode.Atualizar);
        }

        public void Add()
        {
            Pedido p = new Pedido();
            p.Data = DateTime.Now;
            p.Id = 1;
            p.Id_mesa = 2;
            p.Status = 1;
            p.VlTotal = 23.00;
            a.Add(p);
        }

        public void abc()
        {
            dgvConsulta.AutoGenerateColumns = false;
            dgvConsulta.DataSource = a;

            DataGridViewTextBoxColumn colunaNumero = new DataGridViewTextBoxColumn();
            colunaNumero.Name = "Pedido";
            colunaNumero.HeaderText = "Codigo do pedido";
            colunaNumero.DataPropertyName = "Numero";
            colunaNumero.DisplayIndex = 0;
            dgvConsulta.Columns.Add(colunaNumero);
        }
        #endregion
    }
}
