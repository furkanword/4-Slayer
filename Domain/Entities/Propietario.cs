namespace Domain.Entities;

public class Propietario : BaseEntity
{
    public string Nombre { get; set;}
    public string Email {get;set;}
    public int Telefono {get;set;}
    public ICollection<Mascota> Mascotas {get;set;}

}
