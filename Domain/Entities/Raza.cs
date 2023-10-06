namespace Domain.Entities;

public class Raza : BaseEntity
{
    public int Id_especie { get; set;}
    public Especie Especie {get;set;}
    public string Nombre {get;set;}
    public ICollection<Raza> Razas {get;set;}
    public ICollection<Mascota> Mascotas {get;set;}
}
