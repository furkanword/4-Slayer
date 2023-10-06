using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class VeterinarioRepository : GenericRepository<Veterinario> , IVeterinario
{
    private readonly ApiDbContext _context;
    public VeterinarioRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}