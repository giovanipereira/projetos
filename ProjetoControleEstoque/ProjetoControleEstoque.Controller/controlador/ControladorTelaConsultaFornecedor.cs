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

        RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
        Fornecedor fornecedor;

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

        private void ListarFornecedorPorId(int id)
        {
            CarregarListas();
            var Query = from f in listaFornecedores
                        join e in listaEstados on f.Id_uf equals e.Id
                        where f.Id.Equals(id)
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

        private void ListarTodosFornecedores()
        {
            CarregarListas();
            var Query = from f in listaFornecedores
                        join e in listaEstados on f.Id_uf equals e.Id
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

                default:
                    ListarTodosFornecedores();
                    break;
            }
        }

        private void RemoverFornecedor()
        {
            CarregarListas();
            fornecedor = new Fornecedor();
            fornecedor.Id = int.Parse(dgvConsultaFornecedores.CurrentRow.Cells[0].Value.ToString());
            if (Mensagem.MensagemQuestao("Tem certeza que deseja excluír?").Equals(DialogResult.Yes))
            {
                repositorioFornecedor.Remover(fornecedor);
                Mensagem.MensagemExclusao();
                ListarTodosFornecedores();
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
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && cboConsultarPor.Text.Equals("Código"))
            {
                e.Handled = true;
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

        #endregion
    }
}
