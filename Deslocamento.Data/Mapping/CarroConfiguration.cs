using DeslocamentoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslocamentoApi.Data.Mapping
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Carro");

            builder.Property(p => p.Placa)
                .IsRequired()
                .HasColumnName("Placa")
                .HasMaxLength(10);

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(555);
        }
    }
}
