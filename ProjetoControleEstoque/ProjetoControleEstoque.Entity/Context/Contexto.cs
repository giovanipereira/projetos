using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoControleEstoque.Model.dominio;
using ProjetoControleEstoque.Entity.Entidades;

namespace ProjetoControleEstoque.Entity.Context
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name = DBConnectionString") 
        {

        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configura o schema padrão 
            modelBuilder.HasDefaultSchema("dbo");

            // Adiciona as entidades
            modelBuilder.Configurations.Add(new EntidadeCargo());
            modelBuilder.Configurations.Add(new EntidadeCargo());

            base.OnModelCreating(modelBuilder);
        }
    }
}
