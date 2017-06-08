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

        private TextBox txtCodigo, txtNome, txtValorUnitario, txtPorcao, txtDescricao;
        private ComboBox cboFornecedor, cboUnidade, cboSubcategoria, cboCategoria;
        private NumericUpDown nudQtdFornecidas, nudQtdMinima, nudQtdMaxima, nudQtdEstoque;
        private DateTimePicker dtpDataValidade;

        // Declaração das classes 
        ValidacaoProduto validacao;
        Produto produto;
        RepositorioProduto repositorioProduto = new RepositorioProduto();

        #endregion

        #region Constructors

        public ControladorTelaCadastroProduto()
        {

        }

        public ControladorTelaCadastroProduto(TextBox txtCodigo, TextBox txtNome, TextBox txtValorUnitario,
            TextBox txtPorcao, TextBox txtDescricao, ComboBox cboFornecedor, ComboBox cboUnidade,
            ComboBox cboSubcategoria, ComboBox cboCategoria, 
            NumericUpDown nudQtdFornecidas, NumericUpDown nudQtdEstoque,
            NumericUpDown nudQtdMinima, NumericUpDown nudQtdMaxima, DateTimePicker mskDataValidade,
            Button btnInserir, Button btnSalvar, Button btnAtualizar, Button btnCancelar)
        {
            this.txtCodigo = txtCodigo;
            this.txtNome = txtNome;
            this.txtValorUnitario = txtValorUnitario;
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
            this.dtpDataValidade = mskDataValidade;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            AdicionarListaControles();
        }

        #endregion

        #region Private Methods
        private Produto CarregarProduto(Produto produto)
        {
            decimal porcao, valor_unitario;
            int id;
            //DateTime data;
            produto.Id = int.TryParse(txtCodigo.Text, out id) ? id : 0;
            produto.Nome = txtNome.Text;
            produto.Id_unidade = int.Parse(cboUnidade.SelectedValue.ToString());
            produto.Porcao_pro = decimal.TryParse(txtPorcao.Text, out porcao) ? porcao : 0;
            produto.Valor_unitario = decimal.TryParse(txtValorUnitario.Text.Replace(".00", ""), out valor_unitario) ? valor_unitario : 0;
            produto.Descricao = txtDescricao.Text;
            produto.Qtd_estoque = int.Parse(nudQtdEstoque.Value.ToString());
            produto.Qtd_minima = int.Parse(nudQtdMinima.Value.ToString());
            produto.Qtd_maxima = int.Parse(nudQtdMaxima.Value.ToString());
            produto.Qtd_fornecidas = int.Parse(nudQtdFornecidas.Value.ToString());
            produto.Data_validade = DateTime.Parse(dtpDataValidade.Value.ToString());
            produto.Id_fornecedor = int.Parse(cboFornecedor.SelectedValue.ToString());
            produto.Id_categoria = int.Parse(cboCategoria.SelectedValue.ToString());
            produto.Id_subcategoria = int.Parse(cboSubcategoria.SelectedValue.ToString());
            return produto;
        }

        private void SalvarProduto()
        {
            produto = new Produto();
            produto = CarregarProduto(produto);
            if (repositorioProduto.Salvar(produto))
            {
                Mensagem.MensagemSalvar();
            }

        }

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

        private void PreencherSubcategoria()
        {
            repositorioProduto.PreencherSubcategoria(cboSubcategoria, int.Parse(cboCategoria.SelectedValue.ToString()));
        }
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
            listaControles.Add(txtValorUnitario);
            listaControles.Add(nudQtdEstoque);
            listaControles.Add(txtDescricao);
            listaControles.Add(cboFornecedor);
            listaControles.Add(cboUnidade);
            listaControles.Add(cboSubcategoria);
            listaControles.Add(cboCategoria);
            listaControles.Add(nudQtdFornecidas);
            listaControles.Add(nudQtdMinima);
            listaControles.Add(nudQtdMaxima);
            listaControles.Add(dtpDataValidade);
            listaControles.Add(txtPorcao);
            validacao = new ValidacaoProduto(listaControles);
        }

        #endregion

        #region Event Functions

        public void Load()
        {
            OperationMode((int)EnumOperationMode.Normal);
            PreencherUnidade();
            PreencherFornecedor();
            PreencherCategoria();
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

        public void Atualizar()
        {
            OperationMode((int)EnumOperationMode.Atualizar);
        }

        public void ValorUnitarioLeave()
        {
            // Se não tiver o caracter "."
            if (!txtValorUnitario.Text.Contains(".") && txtValorUnitario.Text == string.Empty)
            {
                //Adicionara ao compoente
                txtValorUnitario.Text += "0.00";
            }
            if (!txtValorUnitario.Text.Contains("."))
            {
                //Adicionara ao compoente
                txtValorUnitario.Text += ".00";
            }
            // Se tiver o caracter "."
            else
                 //O método IndexOf retorna - 1 se encontrar o caractere.
                 if (txtValorUnitario.Text.IndexOf(".") == txtValorUnitario.Text.Length - 1)
                txtValorUnitario.Text += "00";
        }

        public void ValorUnitarioKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorUnitario.Text.Contains("."))
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

        public void CategoriaLeave()
        {
            try
            {
                PreencherSubcategoria();
            }
            catch
            {

            }
        }

        #endregion
    }

}
