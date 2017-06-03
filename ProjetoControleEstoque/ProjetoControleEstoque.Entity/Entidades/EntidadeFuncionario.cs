using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoControleEstoque.Model.dominio;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace ProjetoControleEstoque.Entity.Entidades
{
    public class EntidadeFuncionario : EntityTypeConfiguration<Funcionario>
    {
        public EntidadeFuncionario()
        {
            ToTable("Funcionario");
            HasKey(p => p.Id); // chave estrangeira do usuario
            HasRequired<Cargo>(p => p.Cargo)
                .WithMany(p => p.Funcionarios);

            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Cpf)
                  .IsRequired()
                  .IsConcurrencyToken()
                  .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("ix_cpf") { IsUnique = true }));

            Property(p => p.Email)
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                 new IndexAnnotation(new IndexAttribute("ix_email") { IsUnique = true }))
                .IsRequired();

            Property(p => p.Telefone)
                .IsOptional();
        }
    }
}
