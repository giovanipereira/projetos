using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Mesa
    {
        private int id_mesa;
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public int Id_Mesa
        {
            get { return this.id_mesa; }
            set { this.id_mesa = value; }
        }
    }
}
