using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>{
    public void Configure(EntityTypeBuilder<Medicamento> builder){
        builder.ToTable("Medicamento");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_MedicamentoPK");

        builder.Property(x => x.Id_laboratorio)
            .IsRequired()
            .HasColumnName("ID_LaboratorioFk");

        builder.Property(x => x.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.Property(x => x.Cantidad_disponible)
            .IsRequired()
            .HasColumnName("CantidadDisponible");

        builder.Property(x => x.Precio)
            .IsRequired()
            .HasColumnName("Precio");
        
        builder.HasOne(x => x.Laboratorio)
            .WithMany(x => x.Medicamentos)
            .HasForeignKey(x => x.Id_laboratorio);

        builder.HasMany(p => p.Proveedores)
            .WithMany(p => p.Medicamentos)
            .UsingEntity<Medicamentos_proveedor>(
                t => t.HasOne(j => j.Proveedor)
                    .WithMany(j => j.Medicamentos_Proveedores)
                    .HasForeignKey(j => j.Id_proveedor),

                t => t.HasOne(j => j.Medicamento)
                    .WithMany(j => j.Medicamentos_Proveedores)
                    .HasForeignKey(j => j.Id_medicina),

                t => {//--Configurations
                    t.ToTable("MedicamentosProveedores");
                    t.HasKey(j => new{j.Id_proveedor,j.Id_medicina});
                    
                    t.Property(x => x.Id_proveedor)
                        .HasColumnName("ID_proveedorPK");

                    t.Property(x => x.Id_medicina)
                        .HasColumnName("ID_MedicamentoPK");
                }
            );

            builder.HasData(
                //-La santé
                new{
                    Id=1,
                    Name = "Ampicilina",
                    Stock = 14,
                    Price =(float) 12500,
                    LaboratoryId = 3
                },
                new{
                    Id=2,
                    Name = "Hidrocortizona",
                    Stock = 50,
                    Price =(float) 5500,
                    LaboratoryId = 3
                },
                new{
                    Id=3,
                    Name = "Lorataina",
                    Stock = 30,
                    Price =(float) 3300,
                    LaboratoryId = 3
                },

                //-MK
               
                new{
                    Id=4,
                    Name = "Omeprazol",
                    Stock = 10,
                    Price =(float) 3500,
                    LaboratoryId = 1
                },
                new{
                    Id=5,
                    Name = "Fluoxetina",
                    Stock = 150,
                    Price =(float) 15500,
                    LaboratoryId = 2
                },
                new{
                    Id=6,
                    Name = "Acetamenophen",
                    Stock = 130,
                    Price =(float) 4400,
                    LaboratoryId = 2
                },
                //-Genfar
                new{
                    Id=7,
                    Name = "Ibuprofeno",
                    Stock = 114,
                    Price =(float) 10500,
                    LaboratoryId = 1
                },
                 new{
                    Id=8,
                    Name = "Diclofenalco",
                    Stock = 114,
                    Price =(float) 7800,
                    LaboratoryId = 2
                },
              
                new{
                    Id=9,
                    Name = "Naproxeno",
                    Stock = 430,
                    Price =(float) 6500,
                    LaboratoryId = 1
                }
            );
    }
}