using ProjetoControleEstoque.Model.dominio;
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

        private ComboBox cboFiltro;
        private TextBox txtBusca;
        private Button btnBuscar, btnBuscarTodos, btnAdicionar;
        private DataGridView dgvListaProdutos;

        private List<Produto> listProducts = new List<Produto>();

        #endregion

        #region Constructors
        public ControladorTelaConsultaProduto()
        {

        }

        public ControladorTelaConsultaProduto(ComboBox cboFiltro, TextBox txtBusca, Button btnBuscar,
            Button btnBuscarTodos, Button btnAdicionar, DataGridView dgvListaProdutos)
        {
            this.cboFiltro = cboFiltro;
            this.txtBusca = txtBusca;
            this.btnBuscar = btnBuscar;
            this.btnBuscarTodos = btnBuscarTodos;
            this.btnAdicionar = btnAdicionar;
            this.dgvListaProdutos = dgvListaProdutos;
        }

        #endregion

        private void LoadInfo()
        {
            listProducts.Add(new Produto()
            {
                _codigo = 1,
                _nome = "Goiaba",
                _valor_compra = 2,
                _qntd_estoque = 6,
                _qntd_minima = 4,
                _qntd_fornecidas = 6,
                _qntd_maxima = 10,
                _data_validade = new DateTime(2000, 05, 12),
                _descricao = "N.d.a",
                _codigo_unidade = 1,
                _codigo_fornecedor = 1,
                _codigo_subcategoria = 1
            });
        }

        private void LoadDatagridView()
        {
            dgvListaProdutos.DataSource = listProducts;
        }

        public void Load()
        {
            LoadInfo();
            LoadDatagridView();
        }

        public void AddProduct(Form form)
        {
            form.Show();
        }

    }
}
