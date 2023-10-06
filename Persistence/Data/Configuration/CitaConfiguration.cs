using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>{
    public void Configure(EntityTypeBuilder<Cita> builder){
        builder.ToTable("Cita");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_Cita");

        builder.Property(x => x.Fecha)
            .IsRequired()
            .HasColumnName("Fecha");
        
        builder.Property(x => x.Motivo)
            .IsRequired()
            .HasColumnName("Motivo")
            .HasMaxLength(100);

        
        builder.Property(x => x.Id_veterinario)
            .IsRequired()
            .HasColumnName("ID_VeterinarioFk");
        
        builder.Property(x => x.Id_mascota)
            .IsRequired()
            .HasColumnName("ID_MascotaFk");
        
        builder.HasOne(x => x.Mascota)
            .WithMany(x => x.Citas)
            .HasForeignKey(x => x.Id_mascota);
        
        builder.HasOne(x => x.Veterinario)
            .WithMany(x => x.Citas)
            .HasForeignKey(x => x.Id_veterinario);   

        
        builder.HasData(
            GetData(50)
        );           
    }

   

    private static IEnumerable<Cita> GetData(int numberoFItems){
        string[] razones = {
                "vacunacion",
                "infeccion",
                "terapia",
                "vision"
        };
        Random random = new();
        List<Cita> data = new();
        for (int i = 1; i < numberoFItems; i++){
            
            data.Add(new(){
                Id = i,
                Fecha = DateTime.Now.AddDays(- random.Next(1,365)).AddHours(random.Next(-2, 5)),
                Motivo = razones[random.Next(0,3)],
                Id_mascota = random.Next(1,6),
                Id_veterinario = random.Next(1,3)
            });
        }

        return data;
    }
}