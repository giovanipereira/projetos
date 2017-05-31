using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Funcionario
    {
        #region Fields
        private int id;
        private string nome;
        private long cpf;
        private string email;
        private long telefone;
        private int cargo;
        private int usuario;
        #endregion

        #region Properties
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

        public long Telfone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }

        public int Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public int Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        #endregion
    }
}
