using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Mesa
    {
        #region Field
        private int numero_mesa;
        #endregion

        #region Propertie
        public int Numero_Mesa
        {
            get { return this.numero_mesa; }
            set { this.numero_mesa = value; }
        }
        #endregion
    }
}
