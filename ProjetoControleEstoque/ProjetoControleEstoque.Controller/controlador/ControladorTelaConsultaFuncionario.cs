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
        private Button btnConsultar, btnExcluir;
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
            Button btnExcluir, DataGridView dgvConsultaFuncionarios)
        {
            this.cboConsultarPor = cboConsultarPor;
            this.txtValor = txtValor;
            this.btnConsultar = btnConsultar;
            this.dgvConsultaFuncionarios = dgvConsultaFuncionarios;
            this.btnExcluir = btnExcluir;
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

        private void ListarTodosFuncionarios()
        {
            CarregarListas();
            var Query = from f in listaFuncionarios
                        join c in listaCargos on f.Id_cargo equals c.Id
                        join u in listaUsuarios on f.Id_Usuario equals u.Id
                        join n in listaNiveisAcessos on u.Id_nivel_acesso equals n.Id
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
            }
        }

        private void RemoverFuncionario()
        {
            CarregarListas();
            funcionario = new Funcionario();
            funcionario.Id = int.Parse(dgvConsultaFuncionarios.CurrentRow.Cells[0].Value.ToString());
            funcionario.Id_Usuario = int.Parse(dgvConsultaFuncionarios.CurrentRow.Cells[0].Value.ToString());
            if(Mensagem.MensagemQuestao("Tem certeza que deseja excluír?").Equals(DialogResult.Yes))
            {
                repositorioFuncionario.Remover(funcionario);
                Mensagem.MensagemExclusao();
                ListarTodosFuncionarios();
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
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && cboConsultarPor.Text.Equals("Código"))
            {
                e.Handled = true;
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

        #endregion

    }
}
