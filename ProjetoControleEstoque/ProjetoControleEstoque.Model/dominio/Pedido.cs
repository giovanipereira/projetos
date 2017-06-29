using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Pedido
    {
        private int id;
        private DateTime data;
        private string horario;
        private string status;
        private int id_mesa;
        private string vltotal;
        public virtual Mesa Mesa { get; set; }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public DateTime Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public string Horario
        {
            get { return this.horario; }
            set { this.horario = value; }
        }

        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public int Id_mesa
        {
            get { return this.id_mesa; }
            set { this.id_mesa = value; }
        }

        public string VlTotal
        {
            get { return this.vltotal; }
            set { this.vltotal = value; }
        }
    }
}
