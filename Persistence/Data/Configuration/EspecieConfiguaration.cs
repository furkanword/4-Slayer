using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class EspecieConfiguaration : IEntityTypeConfiguration<Especie>{
    public void Configure(EntityTypeBuilder<Especie> builder){
        builder.ToTable("Especie");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_EspeciePK");
        
        builder.Property(x => x.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);     

        builder.HasData(
            new{
                Id = 1,
                Name = "felina"
            },
            new{
                Id = 2,
                Name = "reptil"
            },
            new{
                Id = 3,
                Name = "ave"
            }
        );
    }
}