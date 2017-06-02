using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoControleEstoque.Model.dominio
{
    [Table("Funcionario")]
    public class Funcionario
    {
        #region Fields
        private Guid id;
        private string nome;
        private long cpf;
        private string email;
        private long telefone;
        private int cargo;
        private Usuario usuario;
        #endregion

        #region Properties

        [Key()]
        [Display(Name = "Código")]
        public Guid Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long Cpf
        {
            get { return this.cpf; }
            set { this.cpf = value; }
        }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        [Display(Name = "Telefone")]
        public long Telfone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }
        [Display(Name = "Cargo")]
        public int Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }
        [Display(AutoGenerateField =false)]
        [ForeignKey("Usuario")]
        public Usuario Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        #endregion
    }
}
