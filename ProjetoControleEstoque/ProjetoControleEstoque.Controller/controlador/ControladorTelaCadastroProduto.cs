using ProjetoControleEstoque.Controller.utility;
using ProjetoControleEstoque.Controller.validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCadastroProduto : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigo, txtNome, txtPrecoCompra, txtPorcao, txtDescricao;
        private ComboBox cboFornecedor, cboUnidade, cboSubcategoria, cboCategoria;
        private NumericUpDown nudQtdFornecidas, nudQtdMinima, nudQtdMaxima, nudQtdEstoque;
        private MaskedTextBox mskDataValidade;

        // Declaração das classes 
        ValidacaoProduto validacao;

        #endregion

        #region Constructors

        public ControladorTelaCadastroProduto()
        {

        }

        public ControladorTelaCadastroProduto(TextBox txtCodigo, TextBox txtNome, TextBox txtPrecoCompra,
            TextBox txtPorcao, TextBox txtDescricao, ComboBox cboFornecedor, ComboBox cboUnidade,
            ComboBox cboSubcategoria, ComboBox cboCategoria, 
            NumericUpDown nudQtdFornecidas, NumericUpDown nudQtdEstoque,
            NumericUpDown nudQtdMinima, NumericUpDown nudQtdMaxima, MaskedTextBox mskDataValidade,
            Button btnInserir, Button btnSalvar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigo = txtCodigo;
            this.txtNome = txtNome;
            this.txtPrecoCompra = txtPrecoCompra;
            this.txtPorcao = txtPorcao;
            this.txtDescricao = txtDescricao;
            this.cboFornecedor = cboFornecedor;
            this.cboUnidade = cboUnidade;
            this.cboSubcategoria = cboSubcategoria;
            this.cboCategoria = cboCategoria;
            this.nudQtdFornecidas = nudQtdFornecidas;
            this.nudQtdEstoque = nudQtdEstoque;
            this.nudQtdMinima = nudQtdMinima;
            this.nudQtdMaxima = nudQtdMaxima;
            this.mskDataValidade = mskDataValidade;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            AdicionarListaControles();
        }

        #endregion

        #region Private Methods


        #endregion

        #region Abstracts Methods

        public override void HabilitarTodosCampos(bool enable)
        {
            validacao.EnableControle(enable);
            txtCodigo.Enabled = false;
        }

        public override void LimparCampos()
        {
            validacao.LimparControl();
        }

        public override void AdicionarListaControles()
        {
            listaControles.Add(txtCodigo);
            listaControles.Add(txtNome);
            listaControles.Add(txtPrecoCompra);
            listaControles.Add(nudQtdEstoque);
            listaControles.Add(txtDescricao);
            listaControles.Add(cboFornecedor);
            listaControles.Add(cboUnidade);
            listaControles.Add(cboSubcategoria);
            listaControles.Add(cboCategoria);
            listaControles.Add(nudQtdFornecidas);
            listaControles.Add(nudQtdMinima);
            listaControles.Add(nudQtdMaxima);
            listaControles.Add(mskDataValidade);
            listaControles.Add(txtPorcao);
            validacao = new ValidacaoProduto(listaControles);
        }

        #endregion

        #region Event Functions

        public void Load()
        {
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Salvar()
        {
            Mensagem.MensagemSalvar();
            OperationMode((int)EnumOperationMode.Normal);
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

        public void PorcaoKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != txtPorcao.MaxLength)
            {
                e.Handled = true;
            }
        }

        #endregion
    }

}
