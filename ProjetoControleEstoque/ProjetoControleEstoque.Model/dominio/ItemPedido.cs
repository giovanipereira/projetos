using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class ItemPedido
    {
        #region Fields
        private int numero_pedido;
        private int id_cardapio;
        private int quantidade;
        private double total_item;
        #endregion

        #region Properties
        public int Numero_Pedido
        {
            get { return this.numero_pedido; }
            set { this.numero_pedido = value; }
        }

        public int Id_Cardapio
        {
            get { return this.id_cardapio; }
            set { this.id_cardapio = value; }
        }

        public int Quantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
        }

        public double Total_Item
        {
            get { return this.total_item; }
            set { this.total_item = value; }
        }

        #endregion
    }
}
