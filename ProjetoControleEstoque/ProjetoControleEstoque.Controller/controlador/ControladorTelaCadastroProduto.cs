using ProjetoControleEstoque.Controller.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCadastroProduto
    {
        #region Declaration

        private TextBox txtCodigo, txtNome, txtPrecoCompra, txtQuantidade, txtDescricao;
        private ComboBox cboFornecedor, cboUnidade, cboSubcategoria, cboCategoria;
        private NumericUpDown nudQntdFornecidas, nudQntdMinima, nudQntdMaxima;
        private MaskedTextBox mskDataValidade;
        private Button btnInserir, btnSalvar, btnAtualizar, btnCancelar;

        // Declaração das listas
        private List<Control> listaControles = new List<Control>();

        // Declaração das classes 
        Validacao validacao;

        #endregion

        #region Constructors

        public ControladorTelaCadastroProduto()
        {

        }

        public ControladorTelaCadastroProduto(TextBox txtCodigo, TextBox txtNome, TextBox txtPrecoCompra,
            TextBox txtQuantidade, TextBox txtDescricao, ComboBox cboFornecedor, ComboBox cboUnidade,
            ComboBox cboSubcategoria, ComboBox cboCategoria, NumericUpDown nudQntdFornecidas,
            NumericUpDown nudQntdMinima, NumericUpDown nudQntdMaxima, MaskedTextBox mskDataValidade,
            Button btnInserir, Button btnSalvar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigo = txtCodigo;
            this.txtNome = txtNome;
            this.txtPrecoCompra = txtPrecoCompra;
            this.txtQuantidade = txtQuantidade;
            this.txtDescricao = txtDescricao;
            this.cboFornecedor = cboFornecedor;
            this.cboUnidade = cboUnidade;
            this.cboSubcategoria = cboSubcategoria;
            this.cboCategoria = cboCategoria;
            this.nudQntdFornecidas = nudQntdFornecidas;
            this.nudQntdMinima = nudQntdMinima;
            this.nudQntdMaxima = nudQntdMaxima;
            this.mskDataValidade = mskDataValidade;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            AdicionarLista();
        }

        #endregion

        #region Public Methods

        // Função que configura o tipo de operação
        public void OperationMode(int option)
        {
            // A variável option recebe um valor que pode ser standard, insert ou update
            // Por padrão os botões de operação vem desabilitados
            btnInserir.Enabled = false;
            btnSalvar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnCancelar.Enabled = false;
            // Desabilitar todos os componentes
            HabilitarCampos(false);
            switch (option)
            {
                // Se for standard
                case 1:
                    // Habilita os botões padrões
                    btnInserir.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Desabilita os componentes
                    HabilitarCampos(false);
                    // E limpa os componentes
                    LimparControles();
                    break;
                // Se for Insert
                case 2:
                    // Habilita os componentes para realizar a operação de salvar
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Habilita os componentes
                    HabilitarCampos(true);
                    break;
                // Se for Update
                case 3:
                    // Habilita os componentes para realizar a operação de atualizar
                    btnAtualizar.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Habilita os componentes
                    HabilitarCampos(true);
                    break;
            }
        }

        #endregion

        #region Private Methods

        private void AdicionarLista()
        {
            listaControles.Add(txtCodigo);
            listaControles.Add(txtNome);
            listaControles.Add(txtPrecoCompra);
            listaControles.Add(txtQuantidade);
            listaControles.Add(txtDescricao);
            listaControles.Add(cboFornecedor);
            listaControles.Add(cboUnidade);
            listaControles.Add(cboSubcategoria);
            listaControles.Add(cboCategoria);
            listaControles.Add(nudQntdFornecidas);
            listaControles.Add(nudQntdMinima);
            listaControles.Add(nudQntdMaxima);
            listaControles.Add(mskDataValidade);
            validacao = new Validacao(listaControles);
        }

        // Função que limpa todos os componentes
        private void LimparControles()
        {
            validacao.LimparControl();
        }

        // Função que habilita os componentes se receber true ou desabilita se receber false
        private void HabilitarCampos(bool enable)
        {
            validacao.EnableControle(enable);
            txtCodigo.Enabled = false;
        }

        private bool ValidarCampoObrigatorio()
        {
            return !validacao.VerificarCampoVazio();
        }

        #endregion

        #region Event Functions

        public void Load()
        {
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Salvar()
        {
            if (!ValidarCampoObrigatorio())
            {
                Mensagem.MensagemSalvar();
                OperationMode((int)EnumOperationMode.Normal);
            }
            
        }

        public void Inserir()
        {
            OperationMode((int)EnumOperationMode.Inserir);
        }

        public void Atualizar()
        {
            OperationMode((int)EnumOperationMode.Atualizar);
        }

        public void PrecoCompraLeave()
        {
            // Se não tiver o caracter "."
            if (!txtPrecoCompra.Text.Contains(".") && txtPrecoCompra.Text == string.Empty)
            {
                //Adicionara ao compoente
                txtPrecoCompra.Text += "0.00";
            }
            if (!txtPrecoCompra.Text.Contains("."))
            {
                //Adicionara ao compoente
                txtPrecoCompra.Text += ".00";
            }
            // Se tiver o caracter "."
            else
                 //O método IndexOf retorna - 1 se encontrar o caractere.
                 if (txtPrecoCompra.Text.IndexOf(".") == txtPrecoCompra.Text.Length - 1)
                txtPrecoCompra.Text += "00";
        }

        public void PrecoCompraKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtPrecoCompra.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        #endregion
    }

}
