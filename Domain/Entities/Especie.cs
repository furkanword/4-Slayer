using System.Reflection.PortableExecutable;
namespace Domain.Entities;

public class Especie : BaseEntity
{
    public string Nombre {get;set;}
    public ICollection<Raza> Razas {get;set;}
    public ICollection<Mascota> Mascotas {get;set;}
}
