using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Cardapio
    {
        private int id;
        private string nome;
        private decimal preco;
        private string figura;
        private string descricao;
        private int id_categoria;
        public virtual CategoriaCardapio Categoria { get; set; }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public decimal Preco
        {
            get { return this.preco; }
            set { this.preco = value; }
        }

        public string Figura
        {
            get { return this.figura; }
            set { this.figura = value; }
        }

        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }

        public int Id_categoria
        {
            get { return this.id_categoria; }
            set { this.id_categoria = value; }
        }
    }
}
