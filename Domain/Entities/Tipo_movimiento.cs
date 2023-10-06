namespace Domain.Entities;

public class Tipo_movimiento : BaseEntity
{
    public string Descripcion { get; set;}
    public ICollection<Movimiento_medicamento> Movimiento_Medicamentos {get;set;}
   
}
