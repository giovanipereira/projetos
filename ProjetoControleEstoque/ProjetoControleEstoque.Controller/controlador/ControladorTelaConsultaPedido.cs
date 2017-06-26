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
    public class ControladorTelaConsultaPedido
    {
        #region Declaration

        private DataGridView dgvConsultaPedidos;

        RepositorioPedido repositorioPedido = new RepositorioPedido();
        IList<Pedido> listaPedido = new List<Pedido>();

        #endregion

        #region Constructors

        public ControladorTelaConsultaPedido()
        {

        }

        public ControladorTelaConsultaPedido(DataGridView dgvConsultaPedidos)
        {
            this.dgvConsultaPedidos = dgvConsultaPedidos;
        }

        #endregion

        #region Private Methods

        private void CarregarListas()
        {
            listaPedido = repositorioPedido.CarregarPedidos();
        }

        private void ListarTodosPedidos()
        {
            CarregarListas();
            var Query = from p in listaPedido
                        orderby p.Horario ascending
                        select new
                        {
                            Pedido = p.Id,
                            Data = p.Data,
                            Horario = p.Horario,
                            Mesa = p.Id_mesa,
                        };
            dgvConsultaPedidos.DataSource = Query.ToList();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvConsultaPedidos.Columns[0].Width = 150;
            dgvConsultaPedidos.Columns[1].Width = 235;
            dgvConsultaPedidos.Columns[2].Width = 185;
            dgvConsultaPedidos.Columns[3].Width = 185;
        }

        #endregion


        public void Load()
        {
            ListarTodosPedidos();
        }
    }
}
