using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Fornecedor
    {
        private int id;
        private string nome;
        private long cnpj;
        private string endereco;
        private string complemento;
        private string bairro;
        private string cidade;
        private int id_uf;
        private long telefone;
        private string email;
        private long cep;
        private bool ativo;
        public virtual Estado Estado { get; set; }

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

        public long Cnpj
        {
            get { return this.cnpj; }
            set { this.cnpj = value; }
        }

        public string Endereco
        {
            get { return this.endereco; }
            set { this.endereco = value; }
        }

        public string Complemento
        {
            get { return this.complemento; }
            set { this.complemento = value; }
        }

        public string Bairro
        {
            get { return this.bairro; }
            set { this.bairro = value; }
        }

        public string Cidade
        {
            get { return this.cidade; }
            set { this.cidade = value; }
        }

        public int Id_uf
        {
            get { return this.id_uf; }
            set { this.id_uf = value; }
        }

        public long Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public long Cep
        {
            get { return this.cep; }
            set { this.cep = value; }
        }

        public bool Ativo
        {
            get { return this.ativo; }
            set { this.ativo = value; }
        }
    }
}
