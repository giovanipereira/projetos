using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Entity.Context
{
    public class Contexto : DbContext
    {
        public Contexto() : base("bd_ControleEstoque") 
        {

        }
    }
}
