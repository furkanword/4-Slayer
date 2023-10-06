using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>{
    public void Configure(EntityTypeBuilder<Propietario> builder){
        builder.ToTable("Propietario");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_PropietarioPK");
        
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

        builder.HasData(
            new{
                Id = 1,
                Name = "Propietario1",
                Email = "Propietario1@gmail.com",
                PhoneNumber = 1234
            },
            new{
                Id = 2,
                Name = "Propietario2",
                Email = "Propietario2@gmail.com",
                PhoneNumber = 1234
            },
            new{
                Id = 3,
                Name = "Propietario3",
                Email = "Propietario3@gmail.com",
                PhoneNumber = 1234
            }
        );
    }
}