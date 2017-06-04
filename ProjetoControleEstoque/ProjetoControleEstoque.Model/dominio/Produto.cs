using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Produto
    {
        private int id;
        private string nome;
        private double valor_compra;
        private int qtd_estoque;
        private int qtd_minima;
        private int qtd_maxima;
        private double medida_pro;
        private DateTime data_validade;
        private string descricao;
        private int qtd_fornecidas;
        private int unidade;
        private int fornecedor;
        private int subcategoria;

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

        public int Qtd_estoque
        {
            get { return this.qtd_estoque; }
            set { this.qtd_estoque = value; }
        }

        public int Qtd_minima
        {
            get { return this.qtd_minima; }
            set { this.qtd_minima = value; }
        }

        public int Qtd_maxima
        {
            get { return this.qtd_maxima; }
            set { this.qtd_maxima = value; }
        }

        public double Medida_pro
        {
            get { return this.medida_pro; }
            set { this.medida_pro = value; }
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

        public int Qtd_fornecidas
        {
            get { return this.qtd_fornecidas; }
            set { this.qtd_fornecidas = value; }
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

    }
}
