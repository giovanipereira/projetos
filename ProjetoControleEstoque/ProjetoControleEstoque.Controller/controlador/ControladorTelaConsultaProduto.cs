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
        private IList<Produto> listaProdutos = new List<Produto>();

        RepositorioProduto repositorioProduto = new RepositorioProduto();

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

        private void TipoConsulta()
        {
            listaProdutos = repositorioProduto.ConsultarTodos();
            string opcao = cboConsultarPor.Text;
            switch (opcao)
            {
                case "Código":
                    if (listaProdutos.Where(p => p.Id.Equals(txtValor.Text)).ToList().Count <= 0)
                    {
                        MessageBox.Show("Codigo do produto nao existe!");
                    }
                    else
                    {
                        listaProdutos.Where(p => p.Id.Equals(txtValor.Text));
                    }
                    dgvConsultaProdutos.DataSource = listaProdutos;
                    break;
                case "Nome":
                    dgvConsultaProdutos.DataSource = repositorioProduto.ConsultarTodos().Where(p => p.Nome.Contains(txtValor.Text)).ToList();
                    break;
            }
        }

        private void LoadDatagridView()
        {
            dgvConsultaProdutos.DataSource = repositorioProduto.ConsultarTodos();
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
