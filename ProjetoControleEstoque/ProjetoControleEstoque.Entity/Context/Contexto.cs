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
        public Contexto() : base("name = DBConnectionString") 
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurar esquema padrão 
            modelBuilder.HasDefaultSchema("dbo");
            //Configure domain classes using modelBuilder here

            base.OnModelCreating(modelBuilder);
        }
    }
}
