using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository ;

public class MedicamentoRepository : GenericRepository<Medicamento> , IMedicamento
{
    private readonly ApiDbContext _context;
    public MedicamentoRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}