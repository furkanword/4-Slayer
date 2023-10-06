using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class Medicamentos_proveedorRepository : GenericRepository<Medicamento> , IMedicamento
{
    private readonly ApiDbContext _context;
    public Medicamentos_proveedorRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}