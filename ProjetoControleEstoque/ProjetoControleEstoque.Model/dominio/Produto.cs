using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Produto
    {
        #region Fields
        private int id;
        private string nome;
        private double valor_compra;
        private int qntd_estoque;
        private int qntd_minima;
        private int qntd_maxima;
        private DateTime data_validade;
        private string descricao;
        private int qntd_fornecidas;
        private int unidade;
        private int fornecedor;
        private int subcategoria;
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

        public double Valor_compra
        {
            get { return this.valor_compra; }
            set { this.valor_compra = value; }
        }

        public int Qntd_estoque
        {
            get { return this.qntd_estoque; }
            set { this.qntd_estoque = value; }
        }

        public int Qntd_minima
        {
            get { return this.qntd_minima; }
            set { this.qntd_minima = value; }
        }

        public int Qntd_maxima
        {
            get { return this.qntd_maxima; }
            set { this.qntd_maxima = value; }
        }

        public DateTime Data_validade
        {
            get { return this.data_validade; }
            set { this.data_validade = value; }
        }

        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }

        public int Qntd_fornecidas
        {
            get { return this.qntd_fornecidas; }
            set { this.qntd_fornecidas = value; }
        }

        public int Unidade
        {
            get { return this.unidade; }
            set { this.unidade = value; }
        }

        public int Fornecedor
        {
            get { return this.fornecedor; }
            set { this.fornecedor = value; }
        }

        public int Subcategoria
        {
            get { return this.subcategoria; }
            set { this.subcategoria = value; }
        }
        #endregion

    }
}
