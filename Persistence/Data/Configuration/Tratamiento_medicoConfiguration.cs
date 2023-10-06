using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class Tratamiento_medicoConfiguration : IEntityTypeConfiguration<Tratamiento_medico>{
    public void Configure(EntityTypeBuilder<Tratamiento_medico> builder){
        builder.ToTable("TratamientoMedico");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_TratamientoPk");
        
        builder.Property(x => x.Id_cita)
            .IsRequired()
            .HasColumnName("ID_CitaFk");
        
        builder.Property(x => x.Id_medicamento)
            .IsRequired()
            .HasColumnName("ID_MedicamentoFk");
        
        builder.Property(x => x.Dosis)
            .IsRequired()
            .HasColumnName("Dosis")
            .HasMaxLength(100);
        
        builder.Property(x => x.Fecha_administracion)
            .IsRequired()
            .HasColumnName("FechaAdministracion");

        builder.Property(x => x.Observacion)
            .IsRequired()
            .HasColumnName("Observaciones")
            .HasMaxLength(150);
        
        builder.HasOne(x => x.Cita)
            .WithMany(x => x.Tratamiento_Medicos)
            .HasForeignKey(x => x.Id_cita);
        
        builder.HasOne(x => x.Medicamento)
            .WithMany(x => x.Tratamiento_Medicos)
            .HasForeignKey(x => x.Id_medicamento);                                
    }
}