using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoControleEstoque.Model.dominio
{
    [Table("Mesa")]
    public class Mesa
    {
        #region Fields
        private int numero_mesa;
        #endregion

        #region Properties

        [Key()]
        public int Numero_Mesa
        {
            get { return this.numero_mesa; }
            set { this.numero_mesa = value; }
        }

        public static implicit operator Mesa(int v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
