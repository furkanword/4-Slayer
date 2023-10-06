namespace Domain.Entities;

public class Movimiento_medicamento : BaseEntity
{
    public int Tipo_movimiento_id { get; set;}
    public Tipo_movimiento Tipo_Movimiento {get;set;}

    public int Cantidad {get;set;}
    public DateTime Fecha {get;set;}

   
    public ICollection<Detalle_movimiento> Detalle_Movimientos {get;set;}
}
