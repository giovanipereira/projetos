using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class ItemCardapio
    {
        private int id_produto;
        //private int id_cardapio;
        private string nome;
        private string unidade;
        private string quantidade;
        //public virtual ICollection<Produto> Produtos { get; set; }
        //public virtual ICollection<Cardapio> Cardapios { get; set; }

        //public int Id_cardapio
        //{
        //    get { return this.id_cardapio; }
        //    set { this.id_cardapio = value; }
        //}

        [DisplayName("Código")]
        public int Id_produto
        {
            get { return this.id_produto; }
            set { this.id_produto = value; }
        }
        [DisplayName("Produto")]
        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }
        [DisplayName("Unidade")]
        public string Unidade
        {
            get { return this.unidade; }
            set { this.unidade = value; }
        }

        [DisplayName("Quantidade")]
        public string Quantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
        }
    }
}
