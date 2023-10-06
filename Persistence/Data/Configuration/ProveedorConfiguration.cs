using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>{
    public void Configure(EntityTypeBuilder<Proveedor> builder){
        builder.ToTable("Proveedor");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_ProveedorPK");                

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
        
    }
}