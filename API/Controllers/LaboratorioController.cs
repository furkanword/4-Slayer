using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class LaboratorioController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public LaboratorioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LaboratorioDto>>> Get()
    {
        var laboratorio = await  _unitofwork.Laboratorios.GetAllAsync();
        return _mapper.Map<List<LaboratorioDto>>(laboratorio);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LaboratorioDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Citas.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<LaboratorioDto>>(pag.registros);
        return new Pager<LaboratorioDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }



     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Laboratorios.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Laboratorio>> Post(LaboratorioDto laboratorioDto){
        var laboratorio = _mapper.Map<Laboratorio>(laboratorioDto);
        this._unitofwork.Laboratorios.Add(laboratorio);
        await _unitofwork.SaveAsync();
        if(laboratorio == null)
        {
            return BadRequest();
        }
        laboratorioDto.Id = laboratorio.Id;
        return CreatedAtAction(nameof(Post),new {id= laboratorioDto.Id}, laboratorioDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Laboratorio>> Put(int id, [FromBody]Laboratorio laboratorio){
        if(laboratorio == null)
            return NotFound();
        _unitofwork.Laboratorios.Update(laboratorio);
        await _unitofwork.SaveAsync();
        return laboratorio;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Laboratorios.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Laboratorios.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}