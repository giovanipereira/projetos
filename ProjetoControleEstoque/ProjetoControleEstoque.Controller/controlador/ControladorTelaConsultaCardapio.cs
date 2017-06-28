using ProjetoControleEstoque.Controller.utility;
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
    public class ControladorTelaConsultaCardapio
    {
        #region Declaration

        private ComboBox cboConsultarPor;
        private TextBox txtValor;
        private Button btnConsultar, btnExcluir, btnBuscarTodos;
        private DataGridView dgvConsultaCardapio;

        IList<Cardapio> listaCardapios = new List<Cardapio>();
        IList<CategoriaCardapio> listaCategorias = new List<CategoriaCardapio>();
        IList<ItemCardapio> listaItensCardapio = new List<ItemCardapio>();
        IList<Produto> listaProdutos = new List<Produto>();
        IList<Unidade> listaUnidades = new List<Unidade>();
        IList<ItemPedido> listaItensPedido = new List<ItemPedido>();

        RepositorioCardapio repositorioCardapio = new RepositorioCardapio();
        RepositorioProduto repositorioProduto = new RepositorioProduto();
        RepositorioPedido repositorioPedido = new RepositorioPedido();
        Cardapio cardapio;

        #endregion

        #region Constructors

        public ControladorTelaConsultaCardapio()
        {

        }

        public ControladorTelaConsultaCardapio(ComboBox cboConsultarPor, TextBox txtValor, Button btnConsultar,
            Button btnExcluir, Button btnBuscarTodos, DataGridView dgvConsultaCardapio)
        {
            this.cboConsultarPor = cboConsultarPor;
            this.txtValor = txtValor;
            this.btnConsultar = btnConsultar;
            this.dgvConsultaCardapio = dgvConsultaCardapio;
            this.btnExcluir = btnExcluir;
            this.btnBuscarTodos = btnBuscarTodos;
        }
        #endregion

        private void CarregarListas()
        {
            listaCardapios = repositorioCardapio.CarregarCardapios();
            listaCategorias = repositorioCardapio.CarregarCategorias();
        }

        #region Private Methods

        private bool VerificarCardapioExistenteNoItemPedido(int id)
        {
            listaItensPedido = repositorioPedido.CarregarItensPedido();
            if (listaItensPedido.Where(i => i.Id_cardapio.Equals(id)).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ListarCardapioPorId(int id)
        {
            CarregarListas();
            var Query = from c in listaCardapios
                        join cat in listaCategorias on c.Id_categoria equals cat.Id
                        where c.Id.Equals(id)
                        select new
                        {
                            Código = c.Id,
                            Nome = c.Nome,
                            Preço = c.Preco,
                            Categoria = cat.Nome,
                        };
            dgvConsultaCardapio.DataSource = Query.ToList();
        }

        private void ListarCardapioPorNome(string nome)
        {
            CarregarListas();
            var Query = from c in listaCardapios
                        join cat in listaCategorias on c.Id_categoria equals cat.Id
                        where c.Nome.Contains(nome)
                        orderby c.Nome ascending
                        select new
                        {
                            Código = c.Id,
                            Nome = c.Nome,
                            Preço = c.Preco,
                            Categoria = cat.Nome,
                        };
            dgvConsultaCardapio.DataSource = Query.ToList();
        }

        private void ListarTodosCardapios()
        {
            CarregarListas();
            var Query = from c in listaCardapios
                        join cat in listaCategorias on c.Id_categoria equals cat.Id
                        orderby c.Id ascending
                        select new
                        {
                            Código = c.Id,
                            Nome = c.Nome,
                            Preço = c.Preco,
                            Categoria = cat.Nome,
                        };
            dgvConsultaCardapio.DataSource = Query.ToList();
            ConfigurarGrid();
        }

        private void ListarCardapioPorCategoria(string categoria)
        {
            CarregarListas();
            var Query = from c in listaCardapios
                        join cat in listaCategorias on c.Id_categoria equals cat.Id
                        where cat.Nome.Equals(categoria)
                        orderby c.Id ascending
                        select new
                        {
                            Código = c.Id,
                            Nome = c.Nome,
                            Preço = c.Preco,
                            Categoria = cat.Nome,
                        };
            dgvConsultaCardapio.DataSource = Query.ToList();
        }

        private void TipoConsulta()
        {
            string opcao = cboConsultarPor.Text;
            string valor = txtValor.Text;

            switch (opcao)
            {
                case "Código":
                    if (valor.Equals(string.Empty))
                    {
                        ListarCardapioPorNome(valor);
                    }
                    else
                    {
                        ListarCardapioPorId(int.Parse(valor));
                    }
                    break;

                case "Nome":
                    ListarCardapioPorNome(valor);
                    break;

                case "Categoria":
                    if (valor.Equals(string.Empty))
                    {
                        ListarCardapioPorNome(valor);
                    }
                    else
                    {
                        ListarCardapioPorCategoria(valor);
                    }
                    break;

                default:
                    ListarTodosCardapios();
                    break;
            }
        }

        private void ConfigurarGrid()
        {
            dgvConsultaCardapio.Columns[0].Width = 150;
            dgvConsultaCardapio.Columns[1].Width = 235;
            dgvConsultaCardapio.Columns[2].Width = 185;
            dgvConsultaCardapio.Columns[3].Width = 185;
        }

        private void RemoverCardapio()
        {
            if (dgvConsultaCardapio.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaCardapio.CurrentRow.Cells[0].Value.ToString());
                if (!VerificarCardapioExistenteNoItemPedido(id))
                {
                    CarregarListas();
                    cardapio = new Cardapio();
                    cardapio.Id = int.Parse(dgvConsultaCardapio.CurrentRow.Cells[0].Value.ToString());
                    if (Mensagem.MensagemQuestao("Tem certeza que deseja excluír?").Equals(DialogResult.Yes))
                    {
                        repositorioCardapio.Remover(cardapio);
                        Mensagem.MensagemExclusao();
                        ListarTodosCardapios();
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível excluír o cardápio desejado,\npois ele está cadastrado em um pedido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        #endregion

        #region Event Functions

        public void Load()
        {
            ListarTodosCardapios();
        }

        public void Consultar()
        {
            TipoConsulta();
        }

        public object[] ObterDadosCardapio(int id)
        {
            CarregarListas();
            var Query = from c in listaCardapios
                        join cat in listaCategorias on c.Id_categoria equals cat.Id
                        where c.Id.Equals(id)
                        select new
                        {
                            Código = c.Id,
                            Nome = c.Nome,
                            Preço = c.Preco,
                            Categoria = c.Id_categoria,
                            Figura = c.Figura,
                            Descrição = c.Descricao,
                        };
            var cardapio = Query.FirstOrDefault(x => x.Código.Equals(id));
            object[] dados = { cardapio.Código, cardapio.Nome, cardapio.Preço, cardapio.Categoria, cardapio.Figura,
            cardapio.Descrição };
            return dados;
        }

        public void SalvarItensCardapiosTemporariamente(int id)
        {
            Cardapio cardapio = new Cardapio();
            cardapio.Id = id;
            repositorioCardapio.SalvarItemCardapioTemporariamenteParaAlterar(cardapio);
        }

        public void ValorKeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboConsultarPor.Text.Equals("Código"))
            {
                txtValor.MaxLength = 10;
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
            else
            {
                txtValor.MaxLength = 100;
            }
        }

        public void ConsultarPorTextChanged()
        {
            txtValor.Enabled = true;
            txtValor.Clear();
        }

        public void BuscarTodos()
        {
            ListarTodosCardapios();
        }

        public void Remover()
        {
            RemoverCardapio();
        }

        public void ConsultarPorId(int id)
        {
            ListarCardapioPorId(id);
        }
        #endregion
    }
}
