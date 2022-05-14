using JovemProgramadorMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc.Data.Mapeamento
{
    public class EnderecoAlunoMapeamento : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.ToTable("EnderecoAluno");



            builder.HasKey(t => t.Id);

            builder.Property(t => t.IdAluno).HasColumnType("int");
            builder.Property(t => t.Logradouro).HasColumnType("varchar(200)");
            builder.Property(t => t.Complemento).HasColumnType("varchar(200)");
            builder.Property(t => t.Bairro).HasColumnType("varchar(50)");
            builder.Property(t => t.Localidade).HasColumnType("varchar(50)");
            builder.Property(t => t.Uf).HasColumnType("varchar(2)");
            builder.Property(t => t.DDD).HasColumnType("varchar(3)");

        }
    }
}
