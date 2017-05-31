using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Subcategoria
    {
        #region Fields
        private int id;
        private string nome;
        private int categoria;
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

        public int Categoria
        {
            get { return this.categoria; }
            set { this.categoria = value; }
        }
        #endregion
    }
}
