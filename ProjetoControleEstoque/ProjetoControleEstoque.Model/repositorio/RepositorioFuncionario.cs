using ProjetoControleEstoque.Model.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Model.repositorio
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario>
    {
        public override bool Atualizar(Funcionario obj)
        {
            return true;
        }

        public override void Remover(Funcionario obj)
        {
            throw new NotImplementedException();
        }

        public override bool Salvar(Funcionario entidade)
        {
            return true;
        }
    }
}
