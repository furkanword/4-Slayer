using System.Reflection.Emit;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class PropietarioRepository : GenericRepository<Propietario> , IPropietario
{
    private readonly ApiDbContext _context;
    public PropietarioRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}