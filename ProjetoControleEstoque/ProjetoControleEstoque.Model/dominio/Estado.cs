using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Estado
    {
        private int id;
        private string sigla;
        private string descricao;
        public virtual ICollection<Fornecedor> Fornecedores { get; set; }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Sigla
        {
            get { return this.sigla; }
            set { this.sigla = value; }
        }

        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }
    }
}
