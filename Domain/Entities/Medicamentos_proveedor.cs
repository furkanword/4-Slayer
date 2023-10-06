namespace Domain.Entities;

public class Medicamentos_proveedor : BaseEntity
{
    public int Id_proveedor { get; set; }
    public Proveedor Proveedor {get;set;}
    public int Id_medicina { get;set;}
    public Medicamento Medicamento {get;set;}

}