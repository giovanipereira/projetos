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
    public class ControladorTelaCadastroProduto : ControladorBase
    {
        #region Declaration

        private TextBox txtCodigo, txtNome, txtValorUnitario, txtQuantidade, txtDescricao;
        private ComboBox cboFornecedor, cboUnidade, cboSubcategoria, cboCategoria;
        private NumericUpDown nudQtdMinima, nudQtdMaxima, nudQtdEstoque;
        private DateTimePicker dtpDataValidade;

        RepositorioProduto repositorioProduto = new RepositorioProduto();
        Produto produto;
        ValidacaoProduto validacaoProduto;

        #endregion

        #region Constructors

        public ControladorTelaCadastroProduto()
        {

        }

        public ControladorTelaCadastroProduto(TextBox txtCodigo, TextBox txtNome, TextBox txtValorUnitario,
            TextBox txtQuantidade, TextBox txtDescricao, ComboBox cboFornecedor, ComboBox cboUnidade,
            ComboBox cboSubcategoria, ComboBox cboCategoria,
            NumericUpDown nudQtdEstoque,
            NumericUpDown nudQtdMinima, NumericUpDown nudQtdMaxima, DateTimePicker mskDataValidade,
            Button btnInserir, Button btnSalvar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigo = txtCodigo;
            this.txtNome = txtNome;
            this.txtValorUnitario = txtValorUnitario;
            this.txtQuantidade = txtQuantidade;
            this.txtDescricao = txtDescricao;
            this.cboFornecedor = cboFornecedor;
            this.cboUnidade = cboUnidade;
            this.cboSubcategoria = cboSubcategoria;
            this.cboCategoria = cboCategoria;
            this.nudQtdEstoque = nudQtdEstoque;
            this.nudQtdMinima = nudQtdMinima;
            this.nudQtdMaxima = nudQtdMaxima;
            this.dtpDataValidade = mskDataValidade;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            AdicionarListaControles();
        }

        #endregion

        #region Private Methods

        private void PreencherFornecedor()
        {
            repositorioProduto.PreencherFornecedor(cboFornecedor);
        }

        private void PreencherUnidade()
        {
            repositorioProduto.PreencherUnidade(cboUnidade);
        }

        private void PreencherCategoria()
        {
            repositorioProduto.PreencherCategoria(cboCategoria);
        }

        public void PreencherSubcategoria()
        {
            repositorioProduto.PreencherSubcategoria(cboSubcategoria, int.Parse(cboCategoria.SelectedValue.ToString()));
        }

        private Produto PreencherProduto(Produto produto)
        {
            int id;
            produto.Id = int.TryParse(txtCodigo.Text, out id) ? id : 0;
            produto.Nome = txtNome.Text;
            produto.Id_unidade = int.Parse(cboUnidade.SelectedValue.ToString());
            produto.Vlunitario = txtValorUnitario.Text.Replace(",", ".");
            produto.Descricao = txtDescricao.Text;
            if (cboUnidade.Text.Equals("Unidade"))
                produto.Quantidade = nudQtdEstoque.Value.ToString();
            else
            {
                produto.Quantidade = txtQuantidade.Text.Replace(",", ".");
            }
            produto.Qtd_estoque = int.Parse(nudQtdEstoque.Value.ToString());
            produto.Qtd_minima = int.Parse(nudQtdMinima.Value.ToString());
            produto.Qtd_maxima = int.Parse(nudQtdMaxima.Value.ToString());
            produto.Data_validade = DateTime.Parse(dtpDataValidade.Value.ToString());
            produto.Id_fornecedor = int.Parse(cboFornecedor.SelectedValue.ToString());
            produto.Id_subcategoria = int.Parse(cboSubcategoria.SelectedValue.ToString());
            return produto;
        }

        private void SalvarProduto()
        {
            produto = new Produto();
            produto = PreencherProduto(produto);
            if (repositorioProduto.Salvar(produto))
                Mensagem.MensagemSalvar();
        }

        private void AtualizarProduto()
        {
            produto = new Produto();
            produto = PreencherProduto(produto);
            if (repositorioProduto.Atualizar(produto))
                Mensagem.MensagemAtualizar();
        }

        #endregion

        #region Abstracts Methods

        public override void HabilitarTodosCampos(bool enable)
        {
            validacaoProduto.EnableControle(enable);
            txtCodigo.ReadOnly = true;
            cboSubcategoria.Enabled = false;
            txtQuantidade.ReadOnly = true;
        }

        public override void LimparCampos()
        {
            validacaoProduto.LimparControles();
        }

        public override void AdicionarListaControles()
        {
            listaControles.Add(txtCodigo);
            listaControles.Add(txtNome);
            listaControles.Add(txtValorUnitario);
            listaControles.Add(nudQtdEstoque);
            listaControles.Add(txtDescricao);
            listaControles.Add(cboFornecedor);
            listaControles.Add(cboUnidade);
            listaControles.Add(cboSubcategoria);
            listaControles.Add(cboCategoria);
            listaControles.Add(nudQtdMinima);
            listaControles.Add(nudQtdMaxima);
            listaControles.Add(dtpDataValidade);
            listaControles.Add(txtQuantidade);
            validacaoProduto = new ValidacaoProduto(listaControles);
        }

        #endregion

        #region Event Functions

        public void PreencherCombobox()
        {
            PreencherFornecedor();
            PreencherUnidade();
            PreencherCategoria();
        }

        public void Load(int opcao, int id_sub)
        {
            switch (opcao)
            {
                case (int)EnumOperationMode.Normal:
                    PreencherCombobox();
                    OperationMode((int)EnumOperationMode.Normal);
                    break;
                case (int)EnumOperationMode.Atualizar:
                    OperationMode((int)EnumOperationMode.Atualizar);
                    cboSubcategoria.Enabled = true;
                    cboSubcategoria.SelectedValue = id_sub;
                    if (cboUnidade.Text != "Unidade")
                        txtQuantidade.ReadOnly = false;
                    break;
            }
        }

        public void Salvar()
        {
            SalvarProduto();
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Inserir()
        {
            OperationMode((int)EnumOperationMode.Inserir);
        }

        public void Atualizar(Form form)
        {
            AtualizarProduto();
            form.Close();
        }

        public void ValorUnitarioLeave()
        {
            if (!string.IsNullOrEmpty(txtValorUnitario.Text))
            {
                if (!txtValorUnitario.Text.Replace(",",".").Contains(".") && txtValorUnitario.Text.Equals(string.Empty))
                {
                    txtValorUnitario.Text += "0.00";
                }
                if (!txtValorUnitario.Text.Replace(",", ".").Contains("."))
                {
                    txtValorUnitario.Text += ".00";
                }
                else if (txtValorUnitario.Text.Replace(",", ".").IndexOf(".") == txtValorUnitario.Text.Length - 1)
                    txtValorUnitario.Text += "00";
            }

        }

        public void ValorUnitarioKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                if (!txtValorUnitario.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        public void QuantidadeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboUnidade.Text != "Unidade")
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.')
                {
                    if (!txtQuantidade.Text.Contains("."))
                    {
                        e.KeyChar = '.';
                    }
                    else e.Handled = true;
                }
            }
            else
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }

        }

        public void QuantidadeLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantidade.Text))
            {
                if (cboUnidade.Text != "Unidade")
                {
                    if (!txtQuantidade.Text.Replace(",", ".").Contains(".") && txtQuantidade.Text.Equals(string.Empty))
                    {
                        txtQuantidade.Text += "0.00";
                    }
                    if (!txtQuantidade.Text.Replace(",", ".").Contains("."))
                    {
                        txtQuantidade.Text += ".00";
                    }
                    else
                         if (txtQuantidade.Text.Replace(",", ".").IndexOf(".") == txtQuantidade.Text.Length - 1)
                        txtQuantidade.Text += "00";
                }
            }
        }

        public void CategoriaLeave()
        {
            PreencherSubcategoria();
        }

        public void CategoriaTextChanged()
        {
            if (cboCategoria.Text != string.Empty)
            {
                cboSubcategoria.Enabled = true;
                try
                {
                    PreencherSubcategoria();
                }
                catch
                {
                    cboSubcategoria.Text = null;
                }
            }
            else
            {
                cboSubcategoria.Enabled = false;
                cboSubcategoria.Text = null;
            }
        }

        public void UnidadeTextChanged()
        {
            if (cboUnidade.Text.Equals(string.Empty))
            {
                txtQuantidade.ReadOnly = true;
            }
            else if (cboUnidade.Text != "Unidade")
            {
                txtQuantidade.Focus();
                txtQuantidade.ReadOnly = false;
            }
            else if (cboUnidade.Text.Equals("Unidade"))
            {
                txtQuantidade.Clear();
                txtQuantidade.ReadOnly = true;
                nudQtdEstoque.Enabled = true;
            }
        }

        #endregion
    }

}
