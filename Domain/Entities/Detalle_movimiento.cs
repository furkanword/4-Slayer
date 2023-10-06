namespace Domain.Entities;

public class Detalle_movimiento : BaseEntity
{
    public int Id_medicamento { get; set;}
    public Medicamento Medicamento {get;set;}

    public int Id_mov_med {get;set;}
    public Movimiento_medicamento Movimiento_Medicamento {get;set;}


    public int Cantidad {get;set;}
    public int Precio {get;set;}
}
