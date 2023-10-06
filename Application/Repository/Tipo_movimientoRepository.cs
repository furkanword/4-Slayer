using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class Tipo_movimientoRepository : GenericRepository<Tipo_movimiento> , ITipo_movimiento
{
    private readonly ApiDbContext _context;
    public Tipo_movimientoRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}