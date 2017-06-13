using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Subcategoria
    {
        private int id;
        private string nome;
        private int id_categoria;
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

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

        public int Id_categoria
        {
            get { return this.id_categoria; }
            set { this.id_categoria = value; }
        }
    }
}
