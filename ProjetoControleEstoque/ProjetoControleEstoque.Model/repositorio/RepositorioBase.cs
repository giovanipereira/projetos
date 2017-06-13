﻿using ProjetoControleEstoque.Model.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ProjetoControleEstoque.Model.repositorio
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        public abstract bool Atualizar(T obj);

        public IList<T> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public abstract void Remover(T obj);
        public abstract bool Salvar(T entidade);
    }
}
