using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class Detalle_movimientoRepository : GenericRepository<Detalle_movimiento> , IDetalle_movimiento
{
    private readonly ApiDbContext _context;
    public Detalle_movimientoRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}