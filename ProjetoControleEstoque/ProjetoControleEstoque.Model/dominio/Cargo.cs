using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Cargo 
    {
        private int id;
        private string descricao;
        public virtual ICollection<Funcionario> Funcionarios { get; set; }

        public Cargo()
        {
            Funcionarios = new List<Funcionario>();
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }
    }
}
