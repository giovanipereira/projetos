﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class ItemCardapio
    {
        #region Fields

        private Cardapio cardapio;
        private int codigo_produto;
        private string nome_produto;
        private string unidade;
        private double quantidade;

        #endregion

        public ItemCardapio()
        {

        }

        public ItemCardapio(int codigo_produto, string nome_produto, string unidade, double quantidade, Cardapio cardapio)
        {
            this.codigo_produto = codigo_produto;
            this.nome_produto = nome_produto;
            this.unidade = unidade;
            this.quantidade = quantidade;
            this.cardapio = cardapio;
        }

        #region Properties
        public Cardapio _cardapio
        {
            get { return this._cardapio; }
            set { this._cardapio = value; }
        }
        public int _codigo_produto
        {
            get { return this.codigo_produto; }
            set { this.codigo_produto = value; }
        }

        public string _nome_produto
        {
            get { return this.nome_produto; }
            set { this.nome_produto = value; }
        }

        public string _unidade
        {
            get { return this.unidade; }
            set { this.unidade = value; }
        }

        public double _quantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
        }
        #endregion
    }
}