using System.Reflection.Emit;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class RazaRepository : GenericRepository<Raza> , IRaza
{
    private readonly ApiDbContext _context;
    public RazaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}