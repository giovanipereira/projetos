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
        private int codigo;
        private string nome;
        private decimal valor_compra;
        private int qntd_estoque;
        private int qntd_minima;
        private int qntd_maxima;
        private DateTime data_validade;
        private string descricao;
        private int qntd_fornecidas;
        private int codigo_unidade;
        private int codigo_fornecedor;
        private int codigo_subcategoria;
        #endregion


        #region Properties
        public int _codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public string _nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public decimal _valor_compra
        {
            get { return this.valor_compra; }
            set { this.valor_compra = value; }
        }

        public int _qntd_estoque
        {
            get { return this.qntd_estoque; }
            set { this.qntd_estoque = value; }
        }

        public int _qntd_minima
        {
            get { return this.qntd_minima; }
            set { this.qntd_minima = value; }
        }

        public int _qntd_maxima
        {
            get { return this.qntd_maxima; }
            set { this.qntd_maxima = value; }
        }

        public DateTime _data_validade
        {
            get { return this.data_validade; }
            set { this.data_validade = value; }
        }

        public string _descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }

        public int _qntd_fornecidas
        {
            get { return this.qntd_fornecidas; }
            set { this.qntd_fornecidas = value; }
        }

        public int _codigo_unidade
        {
            get { return this.codigo_unidade; }
            set { this.codigo_unidade = value; }
        }

        public int _codigo_fornecedor
        {
            get { return this.codigo_fornecedor; }
            set { this.codigo_fornecedor = value; }
        }

        public int _codigo_subcategoria
        {
            get { return this.codigo_subcategoria; }
            set { this.codigo_subcategoria = value; }
        }
        #endregion
    }
}
