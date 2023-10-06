namespace Domain.Entities;

public class Mascota : BaseEntity
{
    public int Id_propietario { get; set; }
    public Propietario Propietario {get;set;}

    public int Id_especie { get; set; }
    public Especie Especie {get;set;}
    
    public int Id_raza { get; set; }
    public Raza Raza {get;set;}

    public string Nombre { get; set; }
    public DateTime Fecha_nacimiento { get; set; }

    public ICollection<Cita> Citas {get;set;}


}