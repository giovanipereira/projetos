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


        IList<Pedido> listaPedido = new List<Pedido>();
        IList<ItemPedido> listaItensPedido = new List<ItemPedido>();
        IList<Cardapio> listaCardapio = new List<Cardapio>();
        Pedido pedido;

        RepositorioPedido repositorioPedido = new RepositorioPedido();
        RepositorioCardapio repositorioCardapio = new RepositorioCardapio();

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

        public void ListarTodosItensPedido(int id, ListBox listbox)
        {
            listaItensPedido = repositorioPedido.CarregarItensPedido();
            listaCardapio = repositorioCardapio.CarregarCardapios();
            var Query = from i in listaItensPedido
                        join c in listaCardapio on i.Id_cardapio equals c.Id
                        where i.Id_pedido.Equals(id)
                        select new
                        {
                            Código = i.Id_cardapio,
                            Produto = c.Nome,
                            Preço = c.Preco,
                            Quantidade = i.Quantidade
                        };
            listbox.DataSource = Query.ToList();
        }

        #endregion


        public void Load()
        {
            ListarTodosPedidos();
        }

        public void SalvarItensPedidoTemporariamente(int id)
        {
            pedido = new Pedido();
            pedido.Id = id;
            repositorioPedido.SalvarItemPedidoTemporariamenteParaAlterar(pedido);
        }

        public object[] ObterDadosPedido(int id)
        {
            CarregarListas();
            var Query = from p in listaPedido
                        where p.Id.Equals(id)
                        select new
                        {
                            Código = p.Id,
                            Data = p.Data,
                            Horario = p.Horario,
                            Mesa = p.Id_mesa,
                            Status = p.Status,
                            Vltotal = p.VlTotal
                        };
            var pedido = Query.FirstOrDefault(x => x.Código.Equals(id));
            object[] dados = { pedido.Código, pedido.Data, pedido.Horario, pedido.Mesa, pedido.Status, pedido.Vltotal };
            return dados;
        }
    }
}
