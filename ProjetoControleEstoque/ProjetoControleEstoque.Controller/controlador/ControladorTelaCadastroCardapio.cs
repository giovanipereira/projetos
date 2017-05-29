using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoControleEstoque.Model.dominio;
using ProjetoControleEstoque.Controller.utility;

namespace ProjetoControleEstoque.Controller.controlador
{
    public class ControladorTelaCadastroCardapio
    {

        #region Declaration

        private TextBox txtCodigo, txtNome, txtPreco, txtDescricao;
        private PictureBox picFigura;
        private Button btnEscolher, btnRemover, btnSelecionar, btnInserir, btnSalvar, btnAtualizar;
        private Button btnCancelar, btnRemoverItem, btnEditarItem;
        private DataGridView dgvListaProdutos;
        private ComboBox cboCategoria;

        // Declaração das listas
        private List<Control> listControls = new List<Control>();

        // Declaração das classes 
        Cardapio cardapio;
        Validacao validacao;

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
            // Adiciona a Lista
            AddList();
        }

        #endregion

        #region Public Methods

        // Função que habilita ou desabilita os botões de editar e remover itens
        public void EnableButtonItem()
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
        public void ChooseFigura()
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
        public void RemoveFigura()
        {
            picFigura.Image = null;
        }

        // Função que adiciona o produto ao datagridview
        public void AddItem(object item)
        {
            dgvListaProdutos.Rows.Add(item);
            dgvListaProdutos.Refresh();
        }

        // Função que abre o form de consulta produto
        public void SelectProduto(Form form)
        {
            form.ShowDialog();
        }

        // Função que remove os itens do datagridview
        public void RemoveItem()
        {
            // Verifica se contem registros no datagridview
            if (dgvListaProdutos.Rows.Count > 0)
            {
                // Mensagem para confirmação do usuário
                if (Mensagem.MensagemQuestao("Tem certeza que deseja remover esse item?"))
                    dgvListaProdutos.Rows.RemoveAt(dgvListaProdutos.CurrentRow.Index);
            }
        }

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
            EnableAll(false);
            switch (option)
            {
                // Se for standard
                case 1:
                    // Habilita os botões padrões
                    btnInserir.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Desabilita os componentes
                    EnableAll(false);
                    // E limpa os componentes
                    ClearControl();
                    break;
                // Se for Insert
                case 2:
                    // Habilita os componentes para realizar a operação de salvar
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Habilita os componentes
                    EnableAll(true);
                    break;
                // Se for Update
                case 3:
                    // Habilita os componentes para realizar a operação de atualizar
                    btnAtualizar.Enabled = true;
                    btnCancelar.Enabled = true;
                    // Habilita os componentes
                    EnableAll(true);
                    break;
            }
        }

        // Função que edita o item
        public void EditItem()
        {
            EnableButtonItem();
        }

        #endregion

        #region Private Methods

        // Função que adiciona uma lista ao construtor da classe Validacao
        private void AddList()
        {
            listControls.Add(txtCodigo);
            listControls.Add(txtNome);
            listControls.Add(txtPreco);
            listControls.Add(picFigura);
            listControls.Add(txtDescricao);
            listControls.Add(cboCategoria);
            listControls.Add(dgvListaProdutos);
            listControls.Add(btnEscolher);
            listControls.Add(btnRemover);
            listControls.Add(btnSelecionar);
            validacao = new Validacao(listControls);
        }
        // Função que limpa todos os componentes
        private void ClearControl()
        {
            validacao.LimparControl();
        }

        // Função que anexa os valores dos componentes nas propriedades do objeto cardapio
        private void LoadCardapio()
        {
            // Variável para uso no Try parse, onde se acontecer alguma exception na conversão o codigo sera igual a 1
            int codigo;
            cardapio = new Cardapio();
            cardapio._codigo = int.TryParse(txtCodigo.Text, out codigo) ? codigo : 1;
            cardapio._nome = txtNome.Text;
            cardapio._preco = decimal.Parse(txtPreco.Text);
            cardapio._figura = picFigura.ImageLocation;
            cardapio._descricao = txtDescricao.Text;
            cardapio._codigo_categoria = int.Parse(cboCategoria.SelectedValue.ToString());
        }

        // Função que habilita os componentes se receber true ou desabilita se receber false
        private void EnableAll(bool enable)
        {
            // Os componentes que estão com o valor false é porque sempre que for chamado esse método eles não ficaram habilitados
            txtCodigo.Enabled = false;
            btnRemoverItem.Enabled = false;
            btnEditarItem.Enabled = false;
            validacao.EnableControle(enable);
        }

        #endregion

        #region Event Functions

        public void Load()
        {
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Save()
        {
            Mensagem.MensagemSalvar();
            OperationMode((int)EnumOperationMode.Normal);
        }

        public void Insert()
        {
            OperationMode((int)EnumOperationMode.Inserir);
        }

        public void Update()
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
