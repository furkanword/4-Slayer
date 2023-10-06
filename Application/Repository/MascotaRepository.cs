using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class MascotaRepository : GenericRepository<Mascota> , IMascota
{
    private readonly ApiDbContext _context;
    public MascotaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}