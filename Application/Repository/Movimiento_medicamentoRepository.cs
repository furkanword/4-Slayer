using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class Movimiento_medicamentoRepository : GenericRepository<Movimiento_medicamento> , IMovimiento_medicamento
{
    private readonly ApiDbContext _context;
    public Movimiento_medicamentoRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}