using ProjetoControleEstoque.Controller.utility;
using ProjetoControleEstoque.Controller.validacao;
using ProjetoControleEstoque.Model.dominio;
using ProjetoControleEstoque.Model.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCardapioItem : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigoProduto, txtNomeProduto, txtQuantidadeProduto;
        private ComboBox cboUnidadeProduto;
        private Button btnAdicionar;
        RepositorioProduto repositorioProduto = new RepositorioProduto();

        ValidacaoProduto validacao;

        #endregion

        #region Constructors

        public ControladorTelaCardapioItem()
        {

        }

        public ControladorTelaCardapioItem(TextBox txtCodigoProduto, TextBox txtNomeProduto, TextBox txtQuantidadeProduto,
            ComboBox cboUnidadeProduto, Button btnAdicionar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigoProduto = txtCodigoProduto;
            this.txtNomeProduto = txtNomeProduto;
            this.txtQuantidadeProduto = txtQuantidadeProduto;
            this.cboUnidadeProduto = cboUnidadeProduto;
            this.btnAdicionar = btnAdicionar;
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
            txtCodigoProduto.ReadOnly = true;
            txtNomeProduto.ReadOnly = true;
            cboUnidadeProduto.Enabled = false;
        }

        public override void LimparCampos()
        {
            throw new NotImplementedException();
        }

        public override void AdicionarListaControles()
        {
            listaControles.Add(txtCodigoProduto);
            listaControles.Add(txtNomeProduto);
            listaControles.Add(cboUnidadeProduto);
            validacao = new ValidacaoProduto(listaControles);
        }

        #endregion

        public void PreencherUnidade()
        {
            repositorioProduto.PreencherUnidade(cboUnidadeProduto);
        }

        public void Load(int opcao)
        {
            if (opcao.Equals((int)EnumOperationMode.Normal))
            {
                HabilitarTodosCampos(false);
                PreencherUnidade();
                btnAtualizar.Enabled = false;
            }
            else if (opcao.Equals((int)EnumOperationMode.Atualizar))
            {
                HabilitarTodosCampos(false);
                PreencherUnidade();
                txtQuantidadeProduto.Focus();
                btnSalvar.Enabled = false;
            }
        }

        public void QuantidadeProdutoKeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboUnidadeProduto.Text != "Unidade")
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.')
                {
                    if (!txtQuantidadeProduto.Text.Contains("."))
                    {
                        e.KeyChar = '.';
                    }
                    else e.Handled = true;
                }
            }
        }

        public void QuantidadeProdutoLeave()
        {
            if (!string.IsNullOrEmpty(txtQuantidadeProduto.Text))
            {
                if (cboUnidadeProduto.Text != "Unidade")
                {
                    if (!txtQuantidadeProduto.Text.Replace(",", ".").Contains(".") && txtQuantidadeProduto.Text.Equals(string.Empty))
                    {
                        txtQuantidadeProduto.Text += "0.00";
                    }
                    if (!txtQuantidadeProduto.Text.Replace(",", ".").Contains("."))
                    {
                        txtQuantidadeProduto.Text += ".00";
                    }
                    else
                         if (txtQuantidadeProduto.Text.Replace(",", ".").IndexOf(".") == txtQuantidadeProduto.Text.Length - 1)
                        txtQuantidadeProduto.Text += "00";
                }
            }
        }
    }
}