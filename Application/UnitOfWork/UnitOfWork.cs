using Aplicacion.Repository;
using Application.Repository;
using Domain.Interfaces;
using Persistence;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{ 
    private readonly ApiDbContext _context;
    private IRol _rols;
    private IUser _users;
    private ICita _cita;
    private IDetalle_movimiento _detalle_movimiento;
    private IEspecie _especie;
    private ILaboratorio _laboratorio;
    private IMascota _mascota;
    private IMedicamento _medicamento;
    private IMedicamentos_proveedor _medicamentos_proveedor;
    private IMovimiento_medicamento _movimiento_Medicamento;
    private IPropietario _propietario;
    private IProveedor _proveedor;
    private IRaza _raza;
    private ITipo_movimiento _tipo_Movimiento;
    private ITratamiento_medico _tratamiento_Medico;
    private IVeterinario _veterinario;

    

    
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }

    public IUser Users {get{_users ??= new UserRepository(_context); return _users;}}
    public IRol Rols {get{_rols ??= new RolRepository(_context); return _rols;}}
    public ICita Citas {get{_cita ??= new CitaRepository(_context); return _cita;}}
    public IDetalle_movimiento Detalle_Movimientos {get{_detalle_movimiento ??= new Detalle_movimientoRepository(_context); return _detalle_movimiento;}}
    public IEspecie Especies {get{_especie ??= new EspecieRepository(_context); return _especie;}}
    public ILaboratorio Laboratorios {get{_laboratorio ??= new LaboratorioRepository(_context); return _laboratorio;}}
    public IMascota Mascotas {get{_mascota ??= new MascotaRepository(_context); return _mascota;}}
    public IMedicamento Medicamentos {get{_medicamento ??= new MedicamentoRepository(_context); return _medicamento;}}
    public IMovimiento_medicamento Movimiento_Medicamento {get{_movimiento_Medicamento ??= new Movimiento_medicamentoRepository(_context); return _movimiento_Medicamento;}}
    public IPropietario Propietarios {get{_propietario ??= new PropietarioRepository(_context); return _propietario;}}
    public IProveedor Proveedores {get{_proveedor ??= new ProveedorRepository(_context); return _proveedor;}}
    public IRaza Razas {get{_raza ??= new RazaRepository(_context); return _raza;}}
    public ITipo_movimiento Tipo_Movimientos {get{_tipo_Movimiento ??= new Tipo_movimientoRepository(_context); return _tipo_Movimiento;}}
    public ITratamiento_medico Tratamiento_Medicos {get{_tratamiento_Medico ??= new Tratamiento_medicoRepository(_context); return _tratamiento_Medico;}}
    public IVeterinario Veterinarios {get{_veterinario ??= new VeterinarioRepository(_context); return _veterinario;}}

    public IProveedor Proveedor => throw new NotImplementedException();

    public IMovimiento_medicamento Movimiento_Medicamentos => throw new NotImplementedException();

    public ITratamiento_medico Tratamientos_Medicos => throw new NotImplementedException();

    public IMedicamentos_proveedor Medicamentos_Proveedores => throw new NotImplementedException();

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}