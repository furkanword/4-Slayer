
namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IRol Rols {get;} 
    IUser Users {get;} 
    ICita Citas {get;} 
    IDetalle_movimiento Detalle_Movimientos {get;}
    IEspecie Especies{get;}
    IProveedor Proveedor {get;}
    ILaboratorio Laboratorios{get;}
    IMascota Mascotas{get;}
    IMedicamento Medicamentos{get;}
    IMedicamentos_proveedor Medicamentos_Proveedores{get;} 
    IMovimiento_medicamento Movimiento_Medicamentos{get;}
    IPropietario Propietarios {get;}
    IProveedor Proveedores {get;}
    IRaza Razas {get;}
    ITipo_movimiento Tipo_Movimientos {get;}
    ITratamiento_medico Tratamientos_Medicos {get;}
    IVeterinario Veterinarios {get;}

     Task<int> SaveAsync();
}