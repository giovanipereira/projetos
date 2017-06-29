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
    public class ControladorTelaConsultaFuncionario
    {
        #region Declaration

        private ComboBox cboConsultarPor;
        private TextBox txtValor;
        private Button btnConsultar, btnExcluir, btnBuscarTodos;
        private DataGridView dgvConsultaFuncionarios;

        IList<Funcionario> listaFuncionarios = new List<Funcionario>();
        IList<Cargo> listaCargos = new List<Cargo>();
        IList<Usuario> listaUsuarios = new List<Usuario>();
        IList<NivelAcesso> listaNiveisAcessos = new List<NivelAcesso>();

        RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
        Funcionario funcionario;

        #endregion

        #region Constructors

        public ControladorTelaConsultaFuncionario()
        {

        }

        public ControladorTelaConsultaFuncionario(ComboBox cboConsultarPor, TextBox txtValor, Button btnConsultar,
            Button btnExcluir, Button btnBuscarTodos, DataGridView dgvConsultaFuncionarios)
        {
            this.cboConsultarPor = cboConsultarPor;
            this.txtValor = txtValor;
            this.btnConsultar = btnConsultar;
            this.dgvConsultaFuncionarios = dgvConsultaFuncionarios;
            this.btnExcluir = btnExcluir;
            this.btnBuscarTodos = btnBuscarTodos;
        }
        #endregion

        #region Private Methods

        private void CarregarListas()
        {
            listaFuncionarios = repositorioFuncionario.CarregarFuncionarios();
            listaCargos = repositorioFuncionario.CarregarCargos();
            listaUsuarios = repositorioFuncionario.CarregarUsuarios();
            listaNiveisAcessos = repositorioFuncionario.CarregarNiveisAcessos();
        }

        private void ListarFuncionarioPorNome(string nome)
        {
            CarregarListas();
            var Query = from f in listaFuncionarios
                        join c in listaCargos on f.Id_cargo equals c.Id
                        join u in listaUsuarios on f.Id_Usuario equals u.Id
                        join n in listaNiveisAcessos on u.Id_nivel_acesso equals n.Id
                        where f.Nome.Contains(nome)
                        orderby f.Nome ascending
                        select new
                        {
                            Código = f.Id,
                            Nome = f.Nome,
                            CPF = f.Cpf,
                            Cargo = c.Nome,
                            Telefone = f.Telefone,
                            Email = f.Email,
                            Usuário = u.Nome,
                            Nível = n.Nome,
                        };
            dgvConsultaFuncionarios.DataSource = Query.ToList();
        }

        private void ListarFuncionarioPorId(int id)
        {
            CarregarListas();
            var Query = from f in listaFuncionarios
                        join c in listaCargos on f.Id_cargo equals c.Id
                        join u in listaUsuarios on f.Id_Usuario equals u.Id
                        join n in listaNiveisAcessos on u.Id_nivel_acesso equals n.Id
                        where f.Id.Equals(id)
                        select new
                        {
                            Código = f.Id,
                            Nome = f.Nome,
                            CPF = f.Cpf,
                            Cargo = c.Nome,
                            Telefone = f.Telefone,
                            Email = f.Email,
                            Usuário = u.Nome,
                            Nível = n.Nome,
                        };
            dgvConsultaFuncionarios.DataSource = Query.ToList();
        }

        private void ListarFuncionarioPorCpf(long cpf)
        {
            CarregarListas();
            var Query = from f in listaFuncionarios
                        join c in listaCargos on f.Id_cargo equals c.Id
                        join u in listaUsuarios on f.Id_Usuario equals u.Id
                        join n in listaNiveisAcessos on u.Id_nivel_acesso equals n.Id
                        where f.Cpf.Equals(cpf)
                        select new
                        {
                            Código = f.Id,
                            Nome = f.Nome,
                            CPF = f.Cpf,
                            Cargo = c.Nome,
                            Telefone = f.Telefone,
                            Email = f.Email,
                            Usuário = u.Nome,
                            Nível = n.Nome,
                        };
            dgvConsultaFuncionarios.DataSource = Query.ToList();
        }

        private void ListarTodosFuncionarios()
        {
            CarregarListas();
            var Query = from f in listaFuncionarios
                        join c in listaCargos on f.Id_cargo equals c.Id
                        join u in listaUsuarios on f.Id_Usuario equals u.Id
                        join n in listaNiveisAcessos on u.Id_nivel_acesso equals n.Id
                        orderby f.Id ascending
                        select new
                        {
                            Código = f.Id,
                            Nome = f.Nome,
                            CPF = f.Cpf,
                            Cargo = c.Nome,
                            Telefone = f.Telefone,
                            Email = f.Email,
                            Usuário = u.Nome,
                            Nível = n.Nome,
                        };
            dgvConsultaFuncionarios.DataSource = Query.ToList();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvConsultaFuncionarios.Columns[0].Width = 65;
            dgvConsultaFuncionarios.Columns[1].Width = 100;
            dgvConsultaFuncionarios.Columns[5].HeaderText = "E-mail";
            dgvConsultaFuncionarios.Columns[3].Width = 90;
            dgvConsultaFuncionarios.Columns[7].HeaderText = "Nível de Acesso";
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
                        ListarFuncionarioPorNome(valor);
                    }
                    else
                    {
                        ListarFuncionarioPorId(int.Parse(valor));
                    }
                    break;

                case "Nome":
                    ListarFuncionarioPorNome(valor);
                    break;

                case "CPF":
                    if (valor.Equals(string.Empty))
                    {
                        ListarFuncionarioPorNome(valor);
                    }
                    if(txtValor.TextLength < 11)
                    {
                        MessageBox.Show("CPF inválido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtValor.Focus();
                    }
                    else
                    {
                        ListarFuncionarioPorCpf(long.Parse(valor));
                    }
                    break;

                default:
                    ListarTodosFuncionarios();
                    break;
            }
        }

        private void RemoverFuncionario()
        {
            if (dgvConsultaFuncionarios.RowCount > 0)
            {
                CarregarListas();
                funcionario = new Funcionario();
                funcionario.Id = int.Parse(dgvConsultaFuncionarios.CurrentRow.Cells[0].Value.ToString());
                funcionario.Id_Usuario = int.Parse(dgvConsultaFuncionarios.CurrentRow.Cells[0].Value.ToString());
                if (Mensagem.MensagemQuestao("Tem certeza que deseja excluir?").Equals(DialogResult.Yes))
                {
                    repositorioFuncionario.Remover(funcionario);
                    Mensagem.MensagemExclusao();
                    ListarTodosFuncionarios();
                }
            }
        }

        #endregion

        #region Event Functions

        public void Load()
        {
            ListarTodosFuncionarios();
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
            else if (cboConsultarPor.Text.Equals("CPF"))
            {
                txtValor.MaxLength = 11;
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && txtValor.MaxLength <= 11)
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

        public object[] ObterDadosFuncionario(int id)
        {
            CarregarListas();
            var Query = from f in listaFuncionarios
                        join c in listaCargos on f.Id_cargo equals c.Id
                        join u in listaUsuarios on f.Id_Usuario equals u.Id
                        join n in listaNiveisAcessos on u.Id_nivel_acesso equals n.Id
                        where f.Id.Equals(id)
                        select new
                        {
                            Id = f.Id,
                            Nome = f.Nome,
                            Cpf = f.Cpf,
                            Email = f.Email,
                            Telefone = f.Telefone,
                            Cargo = f.Id_cargo,
                            Nível = n.Id,
                            Id_Usuario = f.Id_Usuario,
                            Usuário = u.Nome,
                            Senha = u.Senha,
                        };
            var funcionario = Query.FirstOrDefault(x => x.Id.Equals(id));
            object[] dados = { funcionario.Id, funcionario.Nome, funcionario.Cpf, funcionario.Email,
                    funcionario.Telefone, funcionario.Cargo, funcionario.Nível, funcionario.Id_Usuario ,funcionario.Usuário, funcionario.Senha};
            return dados;
        }

        public void ConsultarPorId(int id)
        {
            ListarFuncionarioPorId(id);
        }

        public void Remover()
        {
            RemoverFuncionario();
        }

        public void BuscarTodos()
        {
            ListarTodosFuncionarios();
        }

        #endregion

    }
}
