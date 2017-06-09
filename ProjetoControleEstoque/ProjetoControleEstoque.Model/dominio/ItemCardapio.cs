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
        private int id_cardapio;
        private string nome;
        private string unidade;
        private double quantidade;

        public int Id_cardapio
        {
            get { return this.id_cardapio; }
            set { this.id_cardapio = value; }
        }
        public int Id_produto
        {
            get { return this.id_produto; }
            set { this.id_produto = value; }
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string Unidade
        {
            get { return this.unidade; }
            set { this.unidade = value; }
        }

        public double Quantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
        }
    }
}
