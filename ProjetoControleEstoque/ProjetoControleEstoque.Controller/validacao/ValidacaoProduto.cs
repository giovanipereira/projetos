using ProjetoControleEstoque.Model.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleEstoque.Controller.validacao
{
    public class ValidacaoProduto : ValidacaoBase<Produto>
    {
        public ValidacaoProduto(List<Control> listaControles) : base(listaControles)
        {
        }

    }
}
