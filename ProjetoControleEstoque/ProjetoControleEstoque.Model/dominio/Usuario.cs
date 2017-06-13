using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Usuario
    {
        private int id;
        private string nome;
        private string senha;
        private int id_nivel_acesso;
        public virtual ICollection<Funcionario> Funcionarios { get; set; }

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

        [DataType(DataType.Password)]
        public string Senha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }

        public int Id_nivel_acesso
        {
            get { return this.id_nivel_acesso; }
            set { this.id_nivel_acesso = value; }
        }
    }
}
