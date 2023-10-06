using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>{
    public void Configure(EntityTypeBuilder<Mascota> builder){
        builder.ToTable("Mascota");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_MascotaPK");
        
        builder.Property(x => x.Id_propietario)
            .IsRequired()
            .HasColumnName("ID_PropietarioFK");
        
        builder.Property(x => x.Id_especie)
            .IsRequired()
            .HasColumnName("ID_EspecieFK");

        builder.Property(x => x.Id_raza)
            .IsRequired()
            .HasColumnName("ID_RazaFK");
        
        builder.Property(x => x.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.Property(x => x.Fecha_nacimiento)
            .IsRequired()
            .HasColumnName("FechaNacimiento");
        
        builder.HasOne(x => x.Propietario)
            .WithMany(x => x.Mascotas)
            .HasForeignKey(x => x.Id_propietario);
        
        builder.HasOne(x => x.Raza)
            .WithMany(x => x.Mascotas)
            .HasForeignKey(x => x.Id_raza);{
            }

        builder.HasOne(x => x.Especie)
            .WithMany(x => x.Mascotas)
            .HasForeignKey(x => x.Id_especie);


        builder.HasData(
            //-Propietario 1
            new{
                Id = 1,
                Name = "apolo",
                Birthdate = DateTime.Now.AddMonths(-15030),
                OwnerId = 1,
                BreedId = 6
            },
            //-Propietario 2
            new{
                Id = 2,
                Name = "spugnik",
                Birthdate = DateTime.Now.AddDays(-30),
                OwnerId = 2,
                BreedId = 7
            },
            new{
                Id = 3,
                Name = "Artemis",
                Birthdate = DateTime.Now.AddDays(-130),
                OwnerId = 2,
                BreedId = 2
            },
            new{
                Id = 4,
                Name = "Pololo",
                Birthdate = DateTime.Now.AddDays(-10),
                OwnerId = 2,
                BreedId = 8
            },
            //propietario 3
            new{
                Id = 5,
                Name = "Aquiles",
                Birthdate = DateTime.Now.AddMonths(-24),
                OwnerId = 3,
                BreedId = 1
            },
            new{
                Id = 6,
                Name = "Stain",
                Birthdate = DateTime.Now.AddDays(-5),
                OwnerId = 3,
                BreedId = 5
            }
        );
    }
}