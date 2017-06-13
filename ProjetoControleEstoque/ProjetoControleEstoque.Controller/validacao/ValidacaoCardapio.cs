using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoControleEstoque.Model.dominio;

namespace ProjetoControleEstoque.Controller.validacao
{
    public class ValidacaoCardapio : ValidacaoBase
    {
        public ValidacaoCardapio(List<Control> listaControles) : base(listaControles)
        {
        }
    }
}
