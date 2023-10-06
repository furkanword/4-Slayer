using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class LaboratorioRepository : GenericRepository<Laboratorio> , ILaboratorio
{
    private readonly ApiDbContext _context;
    public LaboratorioRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}