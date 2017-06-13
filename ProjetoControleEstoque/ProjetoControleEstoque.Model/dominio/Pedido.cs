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
        private DateTime horario;
        private int status;
        private int id_mesa;
        private int id_funcionario;
        private double vltotal;
        public virtual Mesa Mesa { get; set; }
        public virtual Funcionario Funcionario { get; set; }

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

        public DateTime Horario
        {
            get { return this.horario; }
            set { this.horario = value; }
        }

        public int Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public int Id_mesa
        {
            get { return this.id_mesa; }
            set { this.id_mesa = value; }
        }

        public int Id_funcionario
        {
            get { return this.id_funcionario; }
            set { this.id_funcionario = value; }
        }

        public double VlTotal
        {
            get { return this.vltotal; }
            set { this.vltotal = value; }
        }
    }

    public enum EnumStatusPedido
    {
        Pendente = 1,
        Cancelado = 2,
        Finalizado = 3
    }
}
