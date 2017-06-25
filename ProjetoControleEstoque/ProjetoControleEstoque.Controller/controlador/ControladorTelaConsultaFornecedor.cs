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
    public class ControladorTelaConsultaFornecedor
    {
        #region Declaration

        private ComboBox cboConsultarPor;
        private TextBox txtValor;
        private Button btnConsultar, btnExcluir;
        private DataGridView dgvConsultaFornecedores;

        IList<Estado> listaEstados = new List<Estado>();
        IList<Fornecedor> listaFornecedores = new List<Fornecedor>();
        IList<Produto> listaProdutos = new List<Produto>();

        Fornecedor fornecedor;
        RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
        RepositorioProduto repositorioProduto = new RepositorioProduto();

        #endregion

        #region Constructors

        public ControladorTelaConsultaFornecedor()
        {

        }

        public ControladorTelaConsultaFornecedor(ComboBox cboConsultarPor, TextBox txtValor, Button btnConsultar,
            Button btnExcluir, DataGridView dgvConsultaFornecedores)
        {
            this.cboConsultarPor = cboConsultarPor;
            this.txtValor = txtValor;
            this.btnConsultar = btnConsultar;
            this.dgvConsultaFornecedores = dgvConsultaFornecedores;
            this.btnExcluir = btnExcluir;
        }

        #endregion

        #region Private Methods

        private bool VerificarFornecedorExistenteNoProduto(int id)
        {
            listaProdutos = repositorioProduto.CarregarProdutos();
            if (listaProdutos.Where(i => i.Id_fornecedor.Equals(id)).Count() > 0)
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
            listaFornecedores = repositorioFornecedor.CarregarFornecedores();
            listaEstados = repositorioFornecedor.CarregarEstados();
        }

        private void ListarFornecedorPorNome(string nome)
        {
            CarregarListas();
            var Query = from f in listaFornecedores
                        join e in listaEstados on f.Id_uf equals e.Id
                        where f.Nome.Contains(nome)
                        where f.Ativo.Equals(true)
                        orderby f.Nome ascending
                        select new
                        {
                            Código = f.Id,
                            Nome = f.Nome,
                            CNPJ = f.Cnpj,
                            Telefone = f.Telefone,
                            Email = f.Email,
                            Cidade = f.Cidade,
                            Uf = e.Sigla
                        };
            dgvConsultaFornecedores.DataSource = Query.ToList();
        }

        private void ListarFornecedorPorCnpj(long cnpj)
        {
            CarregarListas();
            var Query = from f in listaFornecedores
                        join e in listaEstados on f.Id_uf equals e.Id
                        where f.Cnpj.Equals(cnpj)
                        where f.Ativo.Equals(true)
                        select new
                        {
                            Código = f.Id,
                            Nome = f.Nome,
                            CNPJ = f.Cnpj,
                            Telefone = f.Telefone,
                            Email = f.Email,
                            Cidade = f.Cidade,
                            Uf = e.Sigla
                        };
            dgvConsultaFornecedores.DataSource = Query.ToList();
        }

        private void ListarFornecedorPorId(int id)
        {
            CarregarListas();
            var Query = from f in listaFornecedores
                        join e in listaEstados on f.Id_uf equals e.Id
                        where f.Id.Equals(id)
                        where f.Ativo.Equals(true)
                        select new
                        {
                            Código = f.Id,
                            Nome = f.Nome,
                            CNPJ = f.Cnpj,
                            Telefone = f.Telefone,
                            Email = f.Email,
                            Cidade = f.Cidade,
                            Uf = e.Sigla
                        };
            dgvConsultaFornecedores.DataSource = Query.ToList();
        }

        private void ListarTodosFornecedores()
        {
            CarregarListas();
            var Query = from f in listaFornecedores
                        join e in listaEstados on f.Id_uf equals e.Id
                        where f.Ativo.Equals(true)
                        orderby f.Id ascending
                        select new
                        {
                            Código = f.Id,
                            Nome = f.Nome,
                            CNPJ = f.Cnpj,
                            Telefone = f.Telefone,
                            Email = f.Email,
                            Cidade = f.Cidade,
                            Uf = e.Sigla
                        };
            dgvConsultaFornecedores.DataSource = Query.ToList();
            ConfigurarGrid();
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
                        ListarFornecedorPorNome(valor);
                    }
                    else
                    {
                        ListarFornecedorPorId(int.Parse(valor));
                    }
                    break;

                case "Nome":
                    ListarFornecedorPorNome(valor);
                    break;

                case "CNPJ":
                    if (valor.Equals(string.Empty))
                    {
                        ListarFornecedorPorNome(valor);
                    }
                    if (txtValor.TextLength < 14)
                    {
                        MessageBox.Show("CNPJ inválido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtValor.Focus();
                    }
                    else
                    {
                        ListarFornecedorPorCnpj(long.Parse(valor));
                    }
                    break;

                default:
                    ListarTodosFornecedores();
                    break;
            }
        }

        private void ConfigurarGrid()
        {
            dgvConsultaFornecedores.Columns[0].Width = 93;
            dgvConsultaFornecedores.Columns[1].Width = 162;
            dgvConsultaFornecedores.Columns[4].HeaderText = "E-mail";
        }

        private void RemoverFornecedor()
        {
            if(dgvConsultaFornecedores.RowCount > 0)
            {
                int id = int.Parse(dgvConsultaFornecedores.CurrentRow.Cells[0].Value.ToString());
                if (!VerificarFornecedorExistenteNoProduto(id))
                {
                    CarregarListas();
                    fornecedor = new Fornecedor();
                    fornecedor.Id = id;
                    if (Mensagem.MensagemQuestao("Tem certeza que deseja excluír?").Equals(DialogResult.Yes))
                    {
                        repositorioFornecedor.Remover(fornecedor);
                        Mensagem.MensagemExclusao();
                        ListarTodosFornecedores();
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível excluír o fornecedor desejado,\npois ele está cadastrado em um produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region Events Functions

        public void Load()
        {
            ListarTodosFornecedores();
        }

        public void Consultar()
        {
            TipoConsulta();
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
            else if (cboConsultarPor.Text.Equals("CNPJ"))
            {
                txtValor.MaxLength = 14;
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && txtValor.MaxLength <= 14)
                {
                    e.Handled = true;
                }
            }
            else
            {
                txtValor.MaxLength = 100;
            }
        }

        public void ConsultarPorTextChanged(object sender, EventArgs e)
        {
            txtValor.Enabled = true;
            txtValor.Clear();
        }

        public object[] ObterDadosFornecedor(int id)
        {
            CarregarListas();
            var Query = from f in listaFornecedores
                        join e in listaEstados on f.Id_uf equals e.Id
                        where f.Id.Equals(id)
                        select new
                        {
                            Id = f.Id,
                            Nome = f.Nome,
                            Cnpj = f.Cnpj,
                            Endereco = f.Endereco,
                            Complemento = f.Complemento,
                            Bairro = f.Bairro,
                            Cidade = f.Cidade,
                            Ativo = f.Ativo,
                            Cep = f.Cep,
                            Email = f.Email,
                            Telefone = f.Telefone,
                            Uf = e.Id
                        };
            var fornecedor = Query.FirstOrDefault(x => x.Id.Equals(id));
            object[] dados = { fornecedor.Id, fornecedor.Nome, fornecedor.Cnpj, fornecedor.Endereco,
                    fornecedor.Complemento, fornecedor.Bairro, fornecedor.Cidade, fornecedor.Ativo, fornecedor.Cep,
                    fornecedor.Email, fornecedor.Telefone, fornecedor.Uf };
            return dados;
        }

        public void ConsultarPorId(int id)
        {
            ListarFornecedorPorId(id);
        }

        public void Remover()
        {
            RemoverFornecedor();
        }

        public void BuscarTodos()
        {
            ListarTodosFornecedores();
        }

        #endregion

    }
}
