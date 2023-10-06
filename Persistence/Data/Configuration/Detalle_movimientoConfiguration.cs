using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class Detalle_movimientoConfiguration : IEntityTypeConfiguration<Detalle_movimiento>{
    public void Configure(EntityTypeBuilder<Detalle_movimiento> builder){
        builder.ToTable("DetalleMovimiento");
        builder.HasKey(x => new{ x.Id_medicamento, x.Id_mov_med});

        builder.Property(x => x.Id_medicamento)
            .IsRequired()
            .HasColumnName("ID_ProductoPK");

        builder.Property(x => x.Id_mov_med)
            .IsRequired()
            .HasColumnName("ID_MovMedPK");

        builder.Property(x => x.Cantidad)
            .IsRequired()
            .HasColumnName("Cantidad");
        
        builder.Property(x => x.Precio)
            .IsRequired()
            .HasColumnName("Precio");
        
        builder.HasOne(x => x.Medicamento)
            .WithMany(x => x.Detalle_Movimientos)
            .HasForeignKey(x => x.Id_medicamento);

        builder.HasOne(x => x.Movimiento_Medicamento)
            .WithMany(x => x.Detalle_Movimientos)
            .HasForeignKey(x => x.Id_mov_med);
    }
}