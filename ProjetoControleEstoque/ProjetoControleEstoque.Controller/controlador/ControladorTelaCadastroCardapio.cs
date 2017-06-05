using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoControleEstoque.Model.dominio;
using ProjetoControleEstoque.Controller.utility;
using ProjetoControleEstoque.Controller.validacao;

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

        // Declaração das classes 
        Cardapio cardapio;
        ValidacaoCardapio validacao;

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

        // Função que habilita ou desabilita os botões de editar e remover itens
        public void HabilitarBotaoItem()
        {
            // Verifica se o datagridview tem registros, se tiver habilita os botões de editar e remover item
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

        // Função que seleciona uma figura para a picturebox
        public void EscolherFigura()
        {
            string foto = null;
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.ShowDialog();
            // Se o objeto OpenFileDialog estiver diferente de vazio carregara a foto para a picturebox 
            if (!string.IsNullOrEmpty(OpenFileDialog.FileName))
            {
                foto = OpenFileDialog.FileName;
                picFigura.Load(foto);
            }
        }

        // Função que remove a figura da picturebox
        public void RemoverFigura()
        {
            picFigura.Image = null;
        }

        // Função que abre o form de consulta produto
        public void SelecionarProduto(Form form)
        {
            form.ShowDialog();
        }

        // Função que remove os itens do datagridview
        public void RemoverItem()
        {
            // Verifica se contem registros no datagridview
            if (dgvListaProdutos.Rows.Count > 0)
            {
                // Mensagem para confirmação do usuário
                if (Mensagem.MensagemQuestao("Tem certeza que deseja remover esse item?"))
                    dgvListaProdutos.Rows.RemoveAt(dgvListaProdutos.CurrentRow.Index);
            }
        }

        // ======== não finalizadas =========

        // Função que adiciona o produto ao datagridview
        public void AdicionarItem(object item)
        {
            dgvListaProdutos.Rows.Add(item);
            dgvListaProdutos.Refresh();
        }

        // Função que edita o item
        public void EditarItem()
        {
            HabilitarBotaoItem();
        }

        #endregion

        #region Private and Abstracts Methods

        // Função que adiciona uma lista ao construtor da classe Validacao
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

        // Função que habilita os componentes se receber true ou desabilita se receber false
        public override void HabilitarTodosCampos(bool enable)
        {
            // Os componentes que estão com o valor false é porque sempre que 
            // for chamado esse método eles não ficaram habilitados
            validacao.EnableControle(enable);
            txtCodigo.Enabled = false;
            btnRemoverItem.Enabled = false;
            btnEditarItem.Enabled = false;
        }

        // Função que limpa todos os componentes
        public override void LimparCampos()
        {
            validacao.LimparControl();
        }

        // Função que anexa os valores dos componentes nas propriedades do objeto cardapio
        private void CarregarCardapio()
        {
            // Variável para uso no Try parse, onde se acontecer alguma exception na conversão o 
            // codigo sera igual a 1
            int codigo;
            cardapio = new Cardapio();
            cardapio.Id = int.TryParse(txtCodigo.Text, out codigo) ? codigo : 1;
            cardapio.Nome = txtNome.Text;
            cardapio.Preco = decimal.Parse(txtPreco.Text);
            cardapio.Figura = picFigura.ImageLocation;
            cardapio.Descricao = txtDescricao.Text;
            cardapio.Categoria = int.Parse(cboCategoria.SelectedValue.ToString());
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

        public void PrecoLeave()
        {
            // Se não tiver o caracter "."
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
                txtPreco.Text += "00";
        }

        public void PrecoKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
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