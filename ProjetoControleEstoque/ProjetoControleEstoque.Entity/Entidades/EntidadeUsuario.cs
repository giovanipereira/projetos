using ProjetoControleEstoque.Model.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleEstoque.Entity.Entidades
{
    public class EntidadeUsuario : EntityTypeConfiguration<Usuario>
    {
        public EntidadeUsuario()
        {
            ToTable("Usuario");
            HasRequired(p => p.Funcionarios);
              //  .WithRequiredPrincipal(p => p.);

            Property(p => p.Nome)
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                 new IndexAnnotation(new IndexAttribute("ix_usuario") { IsUnique = true }))
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.Senha)
                .HasMaxLength(30)
                .IsRequired();

            Property(p => p.Id_nivel_acesso)
                .IsRequired();
        }
    }
}
