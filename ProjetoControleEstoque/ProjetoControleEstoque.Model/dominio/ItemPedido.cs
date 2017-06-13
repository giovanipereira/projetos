using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class ItemPedido
    {
        private int id_pedido;
        private int id_cardapio;
        private int quantidade;
        private string observacao;
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Cardapio> Cardapios { get; set; }

        public int Id_pedido
        {
            get { return this.id_pedido; }
            set { this.id_pedido = value; }
        }

        public int Id_cardapio
        {
            get { return this.id_cardapio; }
            set { this.id_cardapio = value; }
        }

        public int Quantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
        }

        public string Observacao
        {
            get { return this.observacao; }
            set { this.observacao = value; }
        }
    }
}
