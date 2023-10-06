namespace Domain.Entities;

public class MascotaDto : BaseEntity
{    
    public string Nombre { get; set; }
    public DateTime Fecha_nacimiento { get; set; }
}