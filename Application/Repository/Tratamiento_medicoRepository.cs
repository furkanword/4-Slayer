using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class Tratamiento_medicoRepository : GenericRepository<Tratamiento_medico> , ITratamiento_medico
{
    private readonly ApiDbContext _context;
    public Tratamiento_medicoRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}