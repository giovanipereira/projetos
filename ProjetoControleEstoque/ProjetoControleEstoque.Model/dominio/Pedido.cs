using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Pedido
    {
        #region Fields
        private int numero;
        private DateTime data;
        private int status;
        private string observacao;
        private Mesa numero_mesa;
        private int funcionario;
        private double valor_total;
        #endregion

        #region Properties
        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public DateTime Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public string Observacao
        {
            get { return this.observacao; }
            set { this.observacao = value; }
        }

        public Mesa Numero_Mesa
        {
            get { return this.numero_mesa; }
            set { this.numero_mesa = value; }
        }

        public int Funcionario
        {
            get { return this.funcionario; }
            set { this.funcionario = value; }
        }

        public double Valor_Total
        {
            get { return this.valor_total; }
            set { this.valor_total = value; }
        }
        #endregion
    }

    public enum EnumStatusPedido
    {
        Pendente = 1,
        Processando = 2,
        Cancelado = 3,
        Finalizado = 4
    }
}
