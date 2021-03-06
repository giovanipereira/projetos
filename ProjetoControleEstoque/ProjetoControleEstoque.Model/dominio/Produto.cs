﻿using System;
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
        private string vlunitario;
        private int qtd_estoque;
        private int qtd_minima;
        private int qtd_maxima;
        private string quantidade;
        private DateTime data_validade;
        private string descricao;
        private int id_unidade;
        private int id_fornecedor;
        private int id_subcategoria;
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Subcategoria Subcategoria { get; set; }
        public virtual Unidade Unidade { get; set; }

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

        public string Vlunitario
        {
            get { return this.vlunitario; }
            set { this.vlunitario = value; }
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

        public string Quantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
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

        public int Id_unidade
        {
            get { return this.id_unidade; }
            set { this.id_unidade = value; }
        }

        public int Id_fornecedor
        {
            get { return this.id_fornecedor; }
            set { this.id_fornecedor = value; }
        }

        public int Id_subcategoria
        {
            get { return this.id_subcategoria; }
            set { this.id_subcategoria = value; }
        }
    }
}
