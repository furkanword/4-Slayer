
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class Tipo_movimientoConfiguration : IEntityTypeConfiguration<Tipo_movimiento>{
    public void Configure(EntityTypeBuilder<Tipo_movimiento> builder){
        builder.ToTable("TipoMovimiento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_TipoFK");
        
        builder.Property(x => x.Descripcion)
            .IsRequired()
            .HasColumnName("Descripcion")
            .HasMaxLength(50);
    }
}