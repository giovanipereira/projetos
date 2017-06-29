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
    public class ControladorTelaConsultaProduto
    {
        #region Declaration

        private ComboBox cboConsultarPor;
        private TextBox txtValor;
        private Button btnConsultar, btnExcluir, btnAdicionar;
        private DataGridView dgvConsultaProdutos;

        IList<Fornecedor> listaFornecedores = new List<Fornecedor>();
        IList<Produto> listaProdutos = new List<Produto>();
        IList<Subcategoria> listaSubcategorias = new List<Subcategoria>();
        IList<Categoria> listaCategorias = new List<Categoria>();
        IList<Unidade> listaUnidades = new List<Unidade>();
        IList<ItemCardapio> listaItensCardapio = new List<ItemCardapio>();

        RepositorioProduto repositorioProduto = new RepositorioProduto();
        RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
        RepositorioCardapio repositorioCardapio = new RepositorioCardapio();
        Produto produto = new Produto();

        #endregion

        #region Constructors

        public ControladorTelaConsultaProduto()
        {

        }

        public ControladorTelaConsultaProduto(ComboBox cboConsultarPor, TextBox txtValor, Button btnConsultar,
            Button btnAdicionar, Button btnExcluir, DataGridView dgvConsultaProdutos)
        {
            this.cboConsultarPor = cboConsultarPor;
            this.txtValor = txtValor;
            this.btnConsultar = btnConsultar;
            this.btnAdicionar = btnAdicionar;
            this.dgvConsultaProdutos = dgvConsultaProdutos;
            this.btnExcluir = btnExcluir;
        }

        #endregion

        #region Private Methods

        private bool VerificarProdutoExistenteNoItemCardapio(int id)
        {
            listaItensCardapio = repositorioCardapio.CarregarItensCardapios();
            if(listaItensCardapio.Where(i => i.Id_produto.Equals(id)).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CarregarListas()
        {
            listaProdutos = repositorioProduto.CarregarProdutos();
            listaFornecedores = repositorioFornecedor.CarregarFornecedores();
            listaUnidades = repositorioProduto.CarregarUnidades();
            listaSubcategorias = repositorioProduto.CarregarSubcategorias();
            listaCategorias = repositorioProduto.CarregarCategorias();
        }

        private void ListarProdutoPorNome(string nome)
        {
            CarregarListas();
            var Query = from p in listaProdutos
                        join f in listaFornecedores on p.Id_fornecedor equals f.Id
                        join u in listaUnidades on p.Id_unidade equals u.Id
                        join s in listaSubcategorias on p.Id_subcategoria equals s.Id
                        join c in listaCategorias on s.Id_categoria equals c.Id
                        where p.Nome.Contains(nome)
                        orderby p.Nome ascending
                        select new
                        {
                            Código = p.Id,
                            Nome = p.Nome,
                            Fornecedor = f.Nome,
                            Categoria = c.Nome,
                            Subcategoria = s.Nome,
                            Estoque = p.Qtd_estoque,
                            Unidade = u.Nome,
                            Quantidade = p.Quantidade
                        };
            dgvConsultaProdutos.DataSource = Query.ToList();
        }

        private void ListarProdutoPorId(int id)
        {
            CarregarListas();
            var Query = from p in listaProdutos
                        join f in listaFornecedores on p.Id_fornecedor equals f.Id
                        join u in listaUnidades on p.Id_unidade equals u.Id
                        join s in listaSubcategorias on p.Id_subcategoria equals s.Id
                        join c in listaCategorias on s.Id_categoria equals c.Id
                        where p.Id.Equals(id)
                        select new
                        {
                            Código = p.Id,
                            Nome = p.Nome,
                            Fornecedor = f.Nome,
                            Categoria = c.Nome,
                            Subcategoria = s.Nome,
                            Estoque = p.Qtd_estoque,
                            Unidade = u.Nome,
                            Quantidade = p.Quantidade
                        };
            dgvConsultaProdutos.DataSource = Query.ToList();
        }

        private void ListarTodosProdutos()
        {
            CarregarListas();
            var Query = from p in listaProdutos
                        join f in listaFornecedores on p.Id_fornecedor equals f.Id
                        join u in listaUnidades on p.Id_unidade equals u.Id
                        join s in listaSubcategorias on p.Id_subcategoria equals s.Id
                        join c in listaCategorias on s.Id_categoria equals c.Id
                        orderby p.Id ascending
                        select new
                        {
                            Código = p.Id,
                            Nome = p.Nome,
                            Fornecedor = f.Nome,
                            Categoria = c.Nome,
                            Subcategoria = s.Nome,
                            Estoque = p.Qtd_estoque,
                            Unidade = u.Nome,
                            Quantidade = p.Quantidade
                        };
            dgvConsultaProdutos.DataSource = Query.ToList();
            ConfigurarGrid();
        }

        private void ListarProdutoPorFornecedor(string fornecedor)
        {
            CarregarListas();
            var Query = from p in listaProdutos
                        join f in listaFornecedores on p.Id_fornecedor equals f.Id
                        join u in listaUnidades on p.Id_unidade equals u.Id
                        join s in listaSubcategorias on p.Id_subcategoria equals s.Id
                        join c in listaCategorias on s.Id_categoria equals c.Id
                        where f.Nome.Equals(fornecedor)
                        orderby p.Nome
                        select new
                        {
                            Código = p.Id,
                            Nome = p.Nome,
                            Fornecedor = f.Nome,
                            Categoria = c.Nome,
                            Subcategoria = s.Nome,
                            Estoque = p.Qtd_estoque,
                            Unidade = u.Nome,
                            Quantidade = p.Quantidade
                        };
            dgvConsultaProdutos.DataSource = Query.ToList();
        }

        private void ListarProdutoPorCategoria(string categoria)
        {
            CarregarListas();
            var Query = from p in listaProdutos
                        join f in listaFornecedores on p.Id_fornecedor equals f.Id
                        join u in listaUnidades on p.Id_unidade equals u.Id
                        join s in listaSubcategorias on p.Id_subcategoria equals s.Id
                        join c in listaCategorias on s.Id_categoria equals c.Id
                        where c.Nome.Equals(categoria)
                        orderby p.Nome
                        select new
                        {
                            Código = p.Id,
                            Nome = p.Nome,
                            Fornecedor = f.Nome,
                            Categoria = c.Nome,
                            Subcategoria = s.Nome,
                            Estoque = p.Qtd_estoque,
                            Unidade = u.Nome,
                            Quantidade = p.Quantidade
                        };
            dgvConsultaProdutos.DataSource = Query.ToList();
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
                        ListarProdutoPorNome(valor);
                    }
                    else
                    {
                        ListarProdutoPorId(int.Parse(valor));
                    }
                    break;

                case "Nome":
                    ListarProdutoPorNome(valor);
                    break;

                case "Fornecedor":
                    if (valor.Equals(string.Empty))
                    {
                        ListarProdutoPorNome(valor);
                    }
                    else
                    {
                        ListarProdutoPorFornecedor(valor);
                    }
                    break;

                case "Categoria":
                    if (valor.Equals(string.Empty))
                    {
                        ListarProdutoPorNome(valor);
                    }
                    else
                    {
                        ListarProdutoPorCategoria(valor);
                    }
                    break;

                default:
                    ListarTodosProdutos();
                    break;
            }
        }

        private void RemoverProduto()
        {
            if(dgvConsultaProdutos.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaProdutos.CurrentRow.Cells[0].Value.ToString());
                if (!VerificarProdutoExistenteNoItemCardapio(id))
                {
                    CarregarListas();
                    produto = new Produto();
                    produto.Id = id;
                    if (Mensagem.MensagemQuestao("Tem certeza que deseja excluir?").Equals(DialogResult.Yes))
                    {
                        repositorioProduto.Remover(produto);
                        Mensagem.MensagemExclusao();
                        ListarTodosProdutos();
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível excluír o produto desejado,\npois ele está cadastrado em um produto do cardápio", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ConfigurarGrid()
        {
            dgvConsultaProdutos.Columns[0].Width = 60;
            dgvConsultaProdutos.Columns[1].Width = 170;
            dgvConsultaProdutos.Columns[5].Width = 60;
            dgvConsultaProdutos.Columns[7].Width = 65;
        }

        #endregion

        #region Event Functions

        public void Load()
        {
            ListarTodosProdutos();
        }

        public void Consultar()
        {
            TipoConsulta();
        }

        public void ConsultarPorTextChanged()
        {
            txtValor.Enabled = true;
            txtValor.Clear();
        }

        public void ValorKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && cboConsultarPor.Text.Equals("Código"))
            {
                e.Handled = true;
            }
        }

        public object[] ObterDadosProduto(int id)
        {
            CarregarListas();
            var Query = from p in listaProdutos
                        join f in listaFornecedores on p.Id_fornecedor equals f.Id
                        join u in listaUnidades on p.Id_unidade equals u.Id
                        join s in listaSubcategorias on p.Id_subcategoria equals s.Id
                        join c in listaCategorias on s.Id_categoria equals c.Id
                        where p.Id.Equals(id)
                        select new
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Valor = p.Vlunitario,
                            Estoque = p.Qtd_estoque,
                            Minimo = p.Qtd_minima,
                            Maximo = p.Qtd_maxima,
                            Quantidade = p.Quantidade,
                            Validade = p.Data_validade,
                            Descricao = p.Descricao,
                            Subcategoria = p.Id_subcategoria,
                            Fornecedor = p.Id_fornecedor,
                            Unidade = p.Id_unidade,
                            Categoria = c.Id
                        };
            var produto = Query.FirstOrDefault(x => x.Id.Equals(id));
            object[] dados = { produto.Id, produto.Nome, produto.Valor, produto.Estoque, produto.Minimo,
            produto.Maximo, produto.Quantidade, produto.Validade, produto.Descricao, produto.Subcategoria, produto.Fornecedor,
            produto.Unidade, produto.Categoria};
            return dados;
        }

        public void ConsultarPorId(int id)
        {
            ListarProdutoPorId(id);
        }

        public void Remover()
        {
            RemoverProduto();
        }

        public void BuscarTodos()
        {
            ListarTodosProdutos();
        }

        #endregion
    }
}
