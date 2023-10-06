using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class EspecieRepository : GenericRepository<Especie> , IEspecie
{
    private readonly ApiDbContext _context;
    public EspecieRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}