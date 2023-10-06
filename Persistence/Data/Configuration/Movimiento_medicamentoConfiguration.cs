using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class Movimiento_medicamentoConfiguration : IEntityTypeConfiguration<Movimiento_medicamento>{
    public void Configure(EntityTypeBuilder<Movimiento_medicamento> builder){
        builder.ToTable("MovimientoMedicamento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_MovMedPK");
        
        builder.Property(x => x.Tipo_movimiento_id)
            .IsRequired()
            .HasColumnName("ID_TipoFK");
                
        
        builder.Property(x => x.Cantidad)
            .IsRequired()
            .HasColumnName("Cantidad");

        builder.Property(x => x.Fecha)
            .IsRequired()
            .HasColumnName("Fecha");
        
        
        builder.HasOne(x => x.Tipo_Movimiento)
            .WithMany(x => x.Movimiento_Medicamentos)
            .HasForeignKey(x => x.Tipo_movimiento_id);   
    }
}