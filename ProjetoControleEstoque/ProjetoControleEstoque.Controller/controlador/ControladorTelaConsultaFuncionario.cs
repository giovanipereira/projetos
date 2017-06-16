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

        private void CarregarListas()
        {
            listaFuncionarios = repositorioFuncionario.CarregarFuncionarios();
            listaCargos = repositorioFuncionario.CarregarCargos();
            listaUsuarios = repositorioFuncionario.CarregarUsuarios();
            listaNiveisAcessos = repositorioFuncionario.CarregarNiveisAcessos();
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

        private void LoadDatagridView()
        {
            ListarTodosFuncionarios();
        }

        public void Load()
        {
            LoadDatagridView();
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

        public object[] Atualizar(int id)
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
                            Usuário = u.Nome,
                            Senha = u.Senha,
                        };
            var funcionario = Query.FirstOrDefault(x => x.Id.Equals(id));
            object[] dados = { funcionario.Id, funcionario.Nome, funcionario.Cpf, funcionario.Email,
                    funcionario.Telefone, funcionario.Cargo, funcionario.Nível, funcionario.Usuário, funcionario.Senha};
            return dados;
        }
    }
}
