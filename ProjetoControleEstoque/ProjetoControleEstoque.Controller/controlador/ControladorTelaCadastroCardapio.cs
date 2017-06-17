using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoControleEstoque.Model.dominio;
using ProjetoControleEstoque.Controller.utility;
using ProjetoControleEstoque.Controller.validacao;
using ProjetoControleEstoque.Model.repositorio;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCadastroCardapio : ControladorBase
    {

        #region Declaration

        private TextBox txtCodigo, txtNome, txtPreco, txtDescricao;
        private PictureBox picFigura;
        private Button btnEscolher, btnRemover, btnSelecionar;
        private Button btnRemoverItem, btnEditarItem;
        private DataGridView dgvListaProdutos;
        private ComboBox cboCategoria;


        Cardapio cardapio;
        ValidacaoCardapio validacao;
        RepositorioCardapio repositorioCardapio = new RepositorioCardapio();

        #endregion

        #region Constructors

        public ControladorTelaCadastroCardapio()
        { 

        }

        public ControladorTelaCadastroCardapio(TextBox txtCodigo, TextBox txtNome, TextBox txtPreco,
            TextBox txtDescricao, PictureBox picFigura, Button btnEscolher, Button btnRemover,
            Button btnSelecionar, Button btnInserir, Button btnSalvar, Button btnAtualizar, Button btnCancelar,
            DataGridView dgvListaProdutos, ComboBox cboCategoria, Button btnRemoverItem, Button btnEditarItem)
        {
            this.txtCodigo = txtCodigo;
            this.txtNome = txtNome;
            this.txtPreco = txtPreco;
            this.txtDescricao = txtDescricao;
            this.picFigura = picFigura;
            this.btnEscolher = btnEscolher;
            this.btnRemover = btnRemover;
            this.btnSelecionar = btnSelecionar;
            this.btnInserir = btnInserir;
            this.btnSalvar = btnSalvar;
            this.btnAtualizar = btnAtualizar;
            this.btnCancelar = btnCancelar;
            this.dgvListaProdutos = dgvListaProdutos;
            this.cboCategoria = cboCategoria;
            this.btnRemoverItem = btnRemoverItem;
            this.btnEditarItem = btnEditarItem;
            AdicionarListaControles();
        }

        #endregion

        #region Public Methods

        public void HabilitarBotaoItem()
        {
            if (dgvListaProdutos.Rows.Count > 0)
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

        public void EscolherFigura()
        {
            string foto = null;
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(OpenFileDialog.FileName))
            {
                foto = OpenFileDialog.FileName;
                picFigura.Load(foto);
            }
        }

        public void RemoverFigura()
        {
            picFigura.Image = null;
        }

        public void SelecionarProduto(Form form)
        {
            form.ShowDialog();
        }

        public void RemoverItem()
        {
            if (dgvListaProdutos.Rows.Count > 0)
            {
                if (Mensagem.MensagemQuestao("Tem certeza que deseja remover esse item?").Equals(DialogResult.Yes))
                    dgvListaProdutos.Rows.RemoveAt(dgvListaProdutos.CurrentRow.Index);
            }
        }

        // ======== não finalizadas =========

        public void AdicionarItem(object item)
        {
            dgvListaProdutos.Rows.Add(item);
            dgvListaProdutos.Refresh();
        }

        public void EditarItem()
        {
            HabilitarBotaoItem();
        }

        #endregion

        #region Private Methods
        private void PreencherCategoria()
        {
            repositorioCardapio.PreencherCategoria(cboCategoria);
        }

        private void SalvarCardapio()
        {
            cardapio = new Cardapio();
            cardapio = CarregarCardapio(cardapio);

            if (repositorioCardapio.Salvar(cardapio))
            {
                Mensagem.MensagemSalvar();
            }
        }

        private Cardapio CarregarCardapio(Cardapio cardapio)
        {
            int codigo;
            cardapio = new Cardapio();
            cardapio.Id = int.TryParse(txtCodigo.Text, out codigo) ? codigo : 0;
            cardapio.Nome = txtNome.Text;
            cardapio.Preco = decimal.Parse(txtPreco.Text);
            cardapio.Figura = picFigura.ImageLocation;
            cardapio.Descricao = txtDescricao.Text;
            cardapio.Id_categoria = int.Parse(cboCategoria.SelectedValue.ToString());
            return cardapio;
        }
        #endregion

        #region Abstracts Methods

        public override void AdicionarListaControles()
        {
            listaControles.Add(txtCodigo);
            listaControles.Add(txtNome);
            listaControles.Add(txtPreco);
            listaControles.Add(picFigura);
            listaControles.Add(txtDescricao);
            listaControles.Add(cboCategoria);
            listaControles.Add(dgvListaProdutos);
            listaControles.Add(btnEscolher);
            listaControles.Add(btnRemover);
            listaControles.Add(btnSelecionar);
            validacao = new ValidacaoCardapio(listaControles);
        }

        public override void HabilitarTodosCampos(bool enable)
        {
            validacao.EnableControle(enable);
            txtCodigo.Enabled = false;
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
            PreencherCategoria();
        }

        public void Salvar()
        {
            SalvarCardapio();
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

        public void PrecoLeave()
        {
         /*   // Se não tiver o caracter "."
            if (!txtPreco.Text.Contains(".") && txtPreco.Text == string.Empty)
            {
                //Adicionara ao compoente
                txtPreco.Text += "0.00";
            }
            if (!txtPreco.Text.Contains("."))
            {
                //Adicionara ao compoente
                txtPreco.Text += ".00";
            }
            // Se tiver o caracter "."
            else
                 //O método IndexOf retorna - 1 se encontrar o caractere.
                 if (txtPreco.Text.IndexOf(".") == txtPreco.Text.Length - 1)
                txtPreco.Text += "00";*/
        }

        public void PrecoKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                if (!txtPreco.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        #endregion
    }
}