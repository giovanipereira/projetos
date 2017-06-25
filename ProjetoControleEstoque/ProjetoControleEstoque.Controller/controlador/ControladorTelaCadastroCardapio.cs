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

        IList<ItemCardapio> listaItensCardapio = new List<ItemCardapio>();
        IList<Unidade> listaUnidades = new List<Unidade>();
        IList<Produto> listaProdutos = new List<Produto>();

        ItemCardapio itemCardapio;
        Cardapio cardapio;
        ValidacaoCardapio validacaoCardapio;
        RepositorioCardapio repositorioCardapio = new RepositorioCardapio();
        RepositorioProduto repositorioProduto = new RepositorioProduto();

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
            picFigura.ImageLocation = null;
        }

        private void CarregarListas()
        {
            listaProdutos = repositorioProduto.CarregarProdutos();
            listaUnidades = repositorioProduto.CarregarUnidades();
        }

        public void ListarProdutos()
        {
            CarregarListas();
            listaItensCardapio = repositorioCardapio.CarregarItensCardapiosTemporarios();
            var Query = from i in listaItensCardapio
                        join p in listaProdutos on i.Id_produto equals p.Id
                        join u in listaUnidades on p.Id_unidade equals u.Id
                        orderby i.Id_cardapio descending
                        select new
                        {
                            Código = p.Id,
                            Nome = p.Nome,
                            Unidade = u.Nome,
                            Quantidade = i.Quantidade
                        };
            if (Query.Count() > 0)
            {
                dgvListaProdutos.DataSource = Query.ToList();
                dgvListaProdutos.Columns[0].Width = 120;
                dgvListaProdutos.Columns[1].Width = 250;
                dgvListaProdutos.Columns[2].Width = 150;
                dgvListaProdutos.Columns[3].Width = 200;
            }
            else
            {
                dgvListaProdutos.DataSource = null;
            }
        }

        public void RemoverTodosItensTemporarios()
        {
            repositorioCardapio.RemoverTodosItensCardapioTemporariamente();
        }

        public int ObterOrdemItem(int id)
        {
            listaItensCardapio = repositorioCardapio.CarregarItensCardapiosTemporarios();
            var Query = from i in listaItensCardapio
                        select new
                        {
                            i.Id_produto,
                            i.Id_cardapio
                        };
            var item = Query.FirstOrDefault(x => x.Id_produto.Equals(id));
            int ordem;
            try
            {
                ordem = item.Id_cardapio;
            }
            catch
            {
                ordem = 0;
            }
            return ordem;
        }

        public object[] ObterDadosItem(int id)
        {
            CarregarListas();
            listaItensCardapio = repositorioCardapio.CarregarItensCardapiosTemporarios();
            var Query = from i in listaItensCardapio
                        join p in listaProdutos on i.Id_produto equals p.Id
                        where i.Id_produto.Equals(id)
                        select new
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Unidade = p.Id_unidade,
                            i.Quantidade
                        };
            var produto = Query.FirstOrDefault(x => x.Id.Equals(id));
            object[] dados = { produto.Id, produto.Nome, produto.Unidade, produto.Quantidade };
            return dados;
        }

        public void RemoverItem()
        {
            if (dgvListaProdutos.Rows.Count > 0)
            {
                if (Mensagem.MensagemQuestao("Tem certeza que deseja remover esse item?").Equals(DialogResult.Yes))
                {
                    itemCardapio = new ItemCardapio();
                    int id = int.Parse(dgvListaProdutos.CurrentRow.Cells[0].Value.ToString());
                    itemCardapio.Id_cardapio = ObterOrdemItem(id);
                    itemCardapio.Id_produto = id;
                    repositorioCardapio.RemoverItemCardapioTemporariamente(itemCardapio);
                    ListarProdutos();
                }
            }
        }

        public void EditarItem()
        {
            HabilitarBotaoItem();
        }

        #endregion

        #region Private Methods

        private bool VerificarCampos()
        {
            bool retorno = false;
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                {
                    Mensagem.MensagemEmpty("Nome");
                    txtNome.Focus();
                    retorno = false;
                }
            }
            else if (string.IsNullOrEmpty(txtPreco.Text))
            {
                {
                    Mensagem.MensagemEmpty("Preço");
                    txtPreco.Focus();
                    retorno = false;
                }
            }
            else if (string.IsNullOrEmpty(cboCategoria.Text))
            {
                {
                    Mensagem.MensagemEmpty("Categoria");
                    cboCategoria.Focus();
                    retorno = false;
                }
            }
            else
            {
                retorno = true;
            }
            return retorno;
        }

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
            if (picFigura.ImageLocation == null)
                cardapio.Figura = string.Empty;
            else
                cardapio.Figura = picFigura.ImageLocation;
            cardapio.Descricao = txtDescricao.Text;
            cardapio.Id_categoria = int.Parse(cboCategoria.SelectedValue.ToString());
            return cardapio;
        }

        private bool SalvarCardapio()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                cardapio = new Cardapio();
                cardapio = PreencherCardapio(cardapio);
                if (dgvListaProdutos.RowCount > 0)
                {
                    if (repositorioCardapio.Salvar(cardapio))
                    {
                        Mensagem.MensagemSalvar();
                        sucesso = true;
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                else
                {
                    MessageBox.Show("Obrigatório adicionar itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sucesso = false;
                }
            }
            return sucesso;
        }

        private bool AtualizarCardapio()
        {
            bool sucesso = false;
            if (VerificarCampos())
            {
                cardapio = new Cardapio();
                cardapio = PreencherCardapio(cardapio);
                if (dgvListaProdutos.RowCount > 0)
                {
                    if (repositorioCardapio.Atualizar(cardapio))
                    {
                        Mensagem.MensagemAtualizar();
                        sucesso = true;
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                else
                {
                    MessageBox.Show("Obrigatório adicionar itens.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sucesso = false;
                }
            }
            return sucesso;
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

        public void PreencherCombobox()
        {
            PreencherCategoria();
        }

        public void Load(int opcao)
        {
            switch (opcao)
            {
                case (int)EnumOperationMode.Normal:
                    PreencherCombobox();
                    OperationMode((int)EnumOperationMode.Normal);
                    break;
                case (int)EnumOperationMode.Atualizar:
                    OperationMode((int)EnumOperationMode.Atualizar);
                    ListarProdutos();
                    break;
            }
        }

        public void Salvar()
        {
            if (SalvarCardapio())
            {
                OperationMode((int)EnumOperationMode.Normal);
            }
        }

        public void Inserir()
        {
            OperationMode((int)EnumOperationMode.Inserir);
        }

        public void Atualizar(Form form)
        {
            if (AtualizarCardapio())
            {
                form.Close();
            }
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