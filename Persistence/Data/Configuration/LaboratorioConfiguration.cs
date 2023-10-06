using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>{
    public void Configure(EntityTypeBuilder<Laboratorio> builder){
        builder.ToTable("Laboratorio");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_LaboratorioPK");                
        
        builder.Property(x => x.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.Property(x => x.Direccion)
            .IsRequired()
            .HasColumnName("Direccion")
            .HasMaxLength(100);
        
        builder.Property(x => x.Telefono)
            .IsRequired()
            .HasColumnName("Telefono")
            .HasMaxLength(50);

        builder.HasData(
            new{
                Id = 1,
                Name = "Sabaneta",
                Address = "centro comercial El tesoro",
                PhoneNumber = 123
            },
            new{
                Id = 2,
                Name = "Comuna 13",
                Address = "San javier",
                PhoneNumber = 456
            },
            new{
                Id = 3,
                Name = "Belen",
                Address = "Avenida siempre Los molinos",
                PhoneNumber = 789
            }
        );
    }
}