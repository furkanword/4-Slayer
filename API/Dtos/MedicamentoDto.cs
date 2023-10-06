namespace Domain.Entities;

public class MedicamentoDto : BaseEntity
{
    public string Nombre { get; set; }
    public int Cantidad_disponible { get; set; }
    public int Precio { get; set; }
}