using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class CitaRepository : GenericRepository<Cita> , ICita
{
    private readonly ApiDbContext _context;
    public CitaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
