namespace Domain.Entities;

public class Medicamento : BaseEntity
{
    public string Nombre { get; set; }
    public int Cantidad_disponible { get; set; }
    public int Precio { get; set; }
    public string Id_laboratorio { get; set; }
    public Laboratorio Laboratorio {get;set;}

    public ICollection<Medicamentos_proveedor> Medicamentos_Proveedores { get; set;}
    public ICollection<Proveedor> Proveedores { get; set; }
    public ICollection<Detalle_movimiento> Detalle_Movimientos {get;set;}
    public ICollection<Movimiento_medicamento> Movimiento_Medicamentos {get;set;}
    public ICollection<Tratamiento_medico> Tratamiento_Medicos {get;set;}
}