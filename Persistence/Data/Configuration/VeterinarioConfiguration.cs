using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>{
    public void Configure(EntityTypeBuilder<Veterinario> builder){
        builder.ToTable("Veterinario");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_VeterinarioPK");
        
        builder.Property(x => x.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("CorreoElectronico")
            .HasMaxLength(100);
        
        builder.Property(x => x.Telefono)
            .IsRequired()
            .HasColumnName("Telefono");

        builder.Property(x => x.Especialidad)
            .IsRequired()
            .HasColumnName("Especialidad")
            .HasMaxLength(100);

        builder.HasData(
            new{
                Id = 1,
                Name = "VeterinarioX",
                Email = "veterinarioa@gmail.com",
                PhoneNumber = 123,
                Specialty = "Cirujano Vascular"
            },
            new{
                Id = 2,
                Name = "Veterinario1XX",
                Email = "veterinariob@gmail.com",
                PhoneNumber = 456,
                Specialty = "Fisioterapia"
            },
            new{
                Id = 3,
                Name = "Veterinario1XXX",
                Email = "veterinarioc@gmail.com",
                PhoneNumber = 7890,
                Specialty = "Oftalmología"
            }
        );
    }
}