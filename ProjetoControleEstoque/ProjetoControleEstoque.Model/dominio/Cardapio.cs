using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.dominio
{
    public class Cardapio
    {
        #region Fields

        private int codigo;
        private string nome;
        private decimal preco;
        private string figura;
        private string descricao;
        private int codigo_categoria;

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

        public decimal _preco
        {
            get { return this.preco; }
            set { this.preco = value; }
        }

        public string _figura
        {
            get { return this.figura; }
            set { this.figura = value; }
        }

        public string _descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }

        public int _codigo_categoria
        {
            get { return this.codigo_categoria; }
            set { this.codigo_categoria = value; }
        }
        #endregion
    }

    public static class ListaCardapio
    {
        public static IEnumerable<Cardapio> getCardapio()
        {
            var cardapios = new List<Cardapio>
            {
                new Cardapio() { _codigo= 1, _nome = "Refreigerante",
                    _preco = 30, _figura= "C:User/Giovani/Projetos/teste.png",
                    _descricao = "Suco",_codigo_categoria = 1},
            };
            return cardapios;
        }
    }
}
