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
            HasRequired(p => p.Funcionario)
                .WithRequiredPrincipal(p => p.Usuario);

            Property(p => p.Nome_Usuario)
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                 new IndexAnnotation(new IndexAttribute("ix_usuario") { IsUnique = true }))
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.Senha)
                .HasMaxLength(30)
                .IsRequired();

            Property(p => p.Nivel_Acesso)
                .IsRequired();

        }
    }
}
