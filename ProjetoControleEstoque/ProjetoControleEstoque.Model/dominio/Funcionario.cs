using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Funcionario
    {
        private int id;
        private string nome;
        private long cpf;
        private string email;
        private long telefone;
        private int id_cargo;
        private int id_usuario;
        //public virtual Cargo Cargo { get; set; }
        //public virtual Usuario Usuario { get; set; }
        //public virtual ICollection<Pedido> Pedidos { get; set; }

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

        public long Cpf
        {
            get { return this.cpf; }
            set { this.cpf = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public long Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }

        public int Id_cargo
        {
            get { return this.id_cargo; }
            set { this.id_cargo = value; }
        }

        public int Id_Usuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

    }
}
