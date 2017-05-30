using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Controller.interfaces
{
    public interface IValidacaoBase<T> where T : class
    {
        void LimparControl();
        void EnableControle(bool enable);
    }
}
