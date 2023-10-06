using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Cita : BaseEntity
{
    public int Id_mascota { get; set; }
    public Mascota Mascota {get;set;}

    public DateTime Fecha { get; set; }
    public DateTime Hora { get; set; }
    public string Motivo { get; set; }

    public int Id_veterinario { get; set;}
    public Veterinario Veterinario { get; set; }

    public ICollection<Cita> Citas {get;set;}
    public ICollection<Tratamiento_medico> Tratamiento_Medicos {get;set;}


}