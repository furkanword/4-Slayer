
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class RazaConfiguration : IEntityTypeConfiguration<Raza>{
    public void Configure(EntityTypeBuilder<Raza> builder){
        builder.ToTable("Raza");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_RazaPK");
        
        builder.Property(x => x.Id_especie)
            .IsRequired()
            .HasColumnName("ID_EspecieFK");
        
        builder.Property(x => x.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.HasOne(x => x.Especie)
            .WithMany(x => x.Razas)
            .HasForeignKey(x => x.Id_especie);   

        builder.HasData(
            //-Felina
            new{
                Id = 1,
                Name = "tigre",
                KindId = 1
            },
            new{
                Id = 2,
                Name = "jaguar",
                KindId = 1
            },
            new{
                Id = 3,
                Name = "león",
                KindId = 1
            },
            //-reptil
            new{
                Id = 4,
                Name = "Cocodrilo",
                KindId = 2
            },
            new{
                Id = 5,
                Name = "serpiente",
                KindId = 2
            },
            new{
                Id = 6,
                Name = "dinosaurio",
                KindId = 2
            },
            //-Ave
            new{
                Id = 7,
                Name = "aguilas",
                KindId = 3
            },
            new{
                Id = 8,
                Name = "Patos",
                KindId = 3
            },
            new{
                Id = 9,
                Name = "Kiwis",
                KindId = 3
            }
        );
    }
}

