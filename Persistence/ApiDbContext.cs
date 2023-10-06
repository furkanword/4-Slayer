using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApiDbContext : DbContext
{
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }
             public DbSet<User> Users { get; set; }
             public DbSet<Rol>  Rols { get; set; }
             public DbSet<UserRol> UsersRols { get; set; }
             public DbSet<Cita> Citas { get; set; }
             public DbSet<Detalle_movimiento> Detalle_Movimientos { get; set; }
             public DbSet<Especie> Especies { get; set; }
             public DbSet<Laboratorio> Laboratorios { get; set; }
             public DbSet<Mascota> Mascotas { get; set; }
             public DbSet<Medicamento> Medicamentos { get; set; }
             public DbSet<Medicamentos_proveedor> Medicamentos_Proveedores { get; set; }
             public DbSet<Movimiento_medicamento> Movimiento_Medicamentos { get; set; }
             public DbSet<Propietario> Propietarios { get; set; }
             public DbSet<Proveedor> Proveedores { get; set; }
             public DbSet<Raza> Razas { get; set; }
             public DbSet<Tipo_movimiento> Tipo_Movimientos { get; set; }
             public DbSet<Tratamiento_medico> Tratamiento_Medicos { get; set; }
             public DbSet<Veterinario> Veterinarios { get; set; }
             

    public override void  Dispose()
    {
        throw new NotImplementedException();
    }


    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

}