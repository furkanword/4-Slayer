using AutoMapper;
using Domain.Entities;
using API.Dtos;
using Application.Repository;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
     { 
            CreateMap<Rol, RolDto>().ReverseMap();

            CreateMap<Cita, CitaDto>().ReverseMap();

            CreateMap<Detalle_movimiento, Detalle_movimientoDto>().ReverseMap();

            CreateMap<Especie, EspecieDto>().ReverseMap();

            CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();

            CreateMap<Mascota, MascotaRepository>().ReverseMap();

            CreateMap<Medicamento, MedicamentoRepository>().ReverseMap();

            CreateMap<Medicamentos_proveedor, Medicamentos_proveedorRepository>().ReverseMap();

            CreateMap<Movimiento_medicamento, Movimiento_medicamentoRepository>().ReverseMap();

            CreateMap<Propietario, PropietarioRepository>().ReverseMap();

            CreateMap<Proveedor, ProveedorDto>().ReverseMap();

            CreateMap<Raza, RazaRepository>().ReverseMap();

            CreateMap<Tipo_movimiento, Tipo_movimientoRepository>().ReverseMap();

            CreateMap<Tratamiento_medico, Tratamiento_medicoRepository>().ReverseMap();

            CreateMap<Veterinario, VeterinarioDto>().ReverseMap();

           

    }
}