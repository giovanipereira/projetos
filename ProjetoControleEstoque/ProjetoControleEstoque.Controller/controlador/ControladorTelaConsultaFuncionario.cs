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

        private void TipoConsulta()
        {
            string opcao = cboConsultarPor.Text;
            switch (opcao)
            {
                case "Código":
                    dgvConsultaFuncionarios.DataSource = repositorioFuncionario.ConsultarTodos().Where(P => P.Id.Equals(txtValor.Text));

                    break;

                case "Nome":
                    dgvConsultaFuncionarios.DataSource = repositorioFuncionario.ConsultarTodos().Where(p => p.Nome.Contains(txtValor.Text)).ToList();
                    break;
            }
        }


        private void LoadDatagridView()
        {
            dgvConsultaFuncionarios.DataSource = repositorioFuncionario.ConsultarTodos();
        }

        public void Load()
        {
            LoadDatagridView();
        }

        public void Consultar()
        {
            TipoConsulta();
        }
    }
}
