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
        RepositorioCardapio repositorioCardapio = new RepositorioCardapio();
        RepositorioProduto repositorioProduto = new RepositorioProduto();
        ItemCardapio itemCardapio;
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

        private bool VerificarCampos()
        {
            bool retorno = false;
            if (string.IsNullOrEmpty(txtQuantidadeProduto.Text))
            {
                Mensagem.MensagemEmpty("Quantidade");
                txtQuantidadeProduto.Focus();
                retorno = false;
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

        private ItemCardapio PreencherItemCardapio(ItemCardapio itemCardapio)
        {
            itemCardapio.Id_produto = int.Parse(txtCodigoProduto.Text);
            itemCardapio.Quantidade = txtQuantidadeProduto.Text;
            return itemCardapio;
        }

        public bool VerificarItemExistente(ItemCardapio itemCardapio)
        {
            IList<ItemCardapio> lista = new List<ItemCardapio>();
            lista = repositorioCardapio.CarregarItensCardapiosTemporarios();
            if (lista.Where(i => i.Id_produto.Equals(itemCardapio.Id_produto)).Count() > 0)
                return true;
            else
            {
                return false;
            }
        }

        private bool SalvarItemCardapio()
        {
            bool retorno = false;
            if (VerificarCampos())
            {
                itemCardapio = new ItemCardapio();
                itemCardapio = PreencherItemCardapio(itemCardapio);
                if (!VerificarItemExistente(itemCardapio))
                {
                    if (repositorioCardapio.SalvarItemCardapioTemporariamente(itemCardapio))
                    {
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                    }
                }
                else
                {
                    MessageBox.Show("Item já adicionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    retorno = true;
                }

                return retorno;
            }
            return retorno;
        }

        private bool AtualizarItemCardapio()
        {
            bool retorno = false;
            if (VerificarCampos())
            {
                itemCardapio = new ItemCardapio();
                itemCardapio = PreencherItemCardapio(itemCardapio);
                if (repositorioCardapio.AtualizarItemCardapioTemporariamente(itemCardapio))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            return retorno;
        }

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
                btnAtualizar.Enabled = false;
            }
            else if (opcao.Equals((int)EnumOperationMode.Atualizar))
            {
                HabilitarTodosCampos(false);
                txtQuantidadeProduto.Focus();
                btnAdicionar.Enabled = false;
            }
        }

        public void Salvar(Form form)
        {
            if (SalvarItemCardapio())
            {
                form.Close();
            }
        }

        public void Atualizar(Form form)
        {
            if (AtualizarItemCardapio())
            {
                form.Close();
            }
        }

        public void QuantidadeProdutoKeyPress(object sender, KeyPressEventArgs e)
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