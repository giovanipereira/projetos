using ProjetoControleEstoque.Model.dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Entity.Entidades
{
    public class EntidadeCargo : EntityTypeConfiguration<Cargo>
    {
        public EntidadeCargo()
        {
            ToTable("Cargo");
            HasKey(p => p.Id);

            Property(p => p.Descricao)
                .HasMaxLength(100)
                .IsRequired();
        }
            
    }
}
