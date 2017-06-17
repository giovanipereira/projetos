using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        bool Salvar(T entidade);
        bool Atualizar(T entidade);
        bool Remover(T entidade);
    }
}
