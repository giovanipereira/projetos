using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Unidade
    {
        private int id;
        private string nome;
        private string sigla;
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

        public string Sigla
        {
            get { return this.sigla; }
            set { this.sigla = value; }
        }
    }
}
