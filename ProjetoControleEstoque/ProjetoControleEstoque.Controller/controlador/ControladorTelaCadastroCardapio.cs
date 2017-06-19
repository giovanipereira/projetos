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
        private Button btnEscolher, btnRemover, btnSelecionar, btnRemoverItem, btnEditarItem;
        private DataGridView dgvListaProdutos;
        private ComboBox cboCategoria;

        Cardapio cardapio;
        ValidacaoCardapio validacaoCardapio;
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
           //if (dgvListaProdutos.Rows.Count > 0)
           // {
           //     if (Mensagem.MensagemQuestao("Tem certeza que deseja remover esse item?").Equals(DialogResult.Yes))
           //         //dgvListaProdutos.Rows.RemoveAt(dgvListaProdutos.CurrentRow.Index);
           //         //lista
           // }
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

        private Cardapio PreencherCardapio(Cardapio cardapio)
        {
            int codigo;
            cardapio.Id = int.TryParse(txtCodigo.Text, out codigo) ? codigo : 0;
            cardapio.Nome = txtNome.Text;
            cardapio.Preco = txtPreco.Text;
            cardapio.Figura = picFigura.ImageLocation;
            cardapio.Descricao = txtDescricao.Text;
            cardapio.Id_categoria = int.Parse(cboCategoria.SelectedValue.ToString());
            return cardapio;
        }

        private void SalvarCardapio()
        {
            cardapio = new Cardapio();
            cardapio = PreencherCardapio(cardapio);
            if (repositorioCardapio.Salvar(cardapio))
                Mensagem.MensagemSalvar();
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
            validacaoCardapio = new ValidacaoCardapio(listaControles);
        }

        public override void HabilitarTodosCampos(bool enable)
        {
            validacaoCardapio.EnableControle(enable);
            txtCodigo.ReadOnly = true;
            btnRemoverItem.Enabled = false;
            btnEditarItem.Enabled = false;
        }

        public override void LimparCampos()
        {
            validacaoCardapio.LimparControles();
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
            if (!string.IsNullOrEmpty(txtPreco.Text))
            {
                if (!txtPreco.Text.Replace(",", ".").Contains(".") && txtPreco.Text.Equals(string.Empty))
                {
                    txtPreco.Text += "0.00";
                }
                if (!txtPreco.Text.Replace(",", ".").Contains("."))
                {
                    txtPreco.Text += ".00";
                }
                else
                     if (txtPreco.Text.Replace(",", ".").IndexOf(".") == txtPreco.Text.Length - 1)
                    txtPreco.Text += "00";
            }
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