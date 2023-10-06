using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class ProveedorRepository : GenericRepository<Proveedor> , IProveedor
{
    private readonly ApiDbContext _context;
    public ProveedorRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}