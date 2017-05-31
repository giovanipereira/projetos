using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Usuario
    {
        #region Fields
        private int id;
        private string nome_usuario;
        private string senha;
        private int nivel_acesso;
        #endregion

        #region Properties
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Nome_Usuario
        {
            get { return this.nome_usuario; }
            set { this.nome_usuario = value; }
        }

        public string Senha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }

        public int Nivel_Acesso
        {
            get { return this.nivel_acesso; }
            set { this.nivel_acesso = value; }
        }
        #endregion
    }

    public enum EnumNivelAcesso
    {
        Administrador = 1,
        Padrao = 2
    }

}
