using DeslocamentoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslocamentoApi.Data.Mapping
{
    public class DeslocamentoConfiguration : IEntityTypeConfiguration<Deslocamento>
    {
        public void Configure(EntityTypeBuilder<Deslocamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Deslocamento");

            builder.Property(p => p.DataHoraInicio)
                .IsRequired()
                .HasColumnName("DataHorarioInicio")
                .HasColumnType("datetime");

            builder.Property(p => p.DataHoraFinal)
                .HasColumnName("DataHorarioFim")
                .HasColumnType("datetime");

            builder.Property(p => p.QuilometragemInicial)
                .HasColumnName("QuilometragemInicial")
                .HasColumnType("decimal");

            builder.Property(p => p.QuilometragemFinal)
                .HasColumnName("QuilometragemFinal")
                .HasColumnType("decimal");

            builder.Property(p => p.Observacao)
                .HasColumnName("Observacao")
                .HasMaxLength(300);

            builder.HasOne(e => e.Carro)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.CarroId)
                .HasConstraintName("FK_Carro_Deslocamento_CarroId");

            builder.HasOne(e => e.Cliente)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.ClienteId)
                .HasConstraintName("FK_Cliente_Deslocamento_ClienteId");

            builder.HasOne(e => e.Condutor)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.CondutorId)
                .HasConstraintName("FK_Condutor_Deslocamento_CondutorId");
        }
    }
}
