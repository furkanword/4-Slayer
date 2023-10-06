using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class Tipo_movimientoController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public Tipo_movimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Tipo_movimientoDto>>> Get()
    {
        var Con = await  _unitofwork.Tipo_Movimientos.GetAllAsync();
        return _mapper.Map<List<Tipo_movimientoDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Tipo_movimientoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Rols.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<Tipo_movimientoDto>>(pag.registros);
        return new Pager<Tipo_movimientoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }



     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Tipo_Movimientos.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Tipo_movimiento>> Post(Tipo_movimientoDto tipo_movimientoDto){
        var tipo_mov = _mapper.Map<Tipo_movimiento>(tipo_movimientoDto);
        this._unitofwork.Tipo_Movimientos.Add(tipo_mov);
        await _unitofwork.SaveAsync();
        if(tipo_mov == null)
        {
            return BadRequest();
        }
        tipo_movimientoDto.Id = tipo_mov.Id;
        return CreatedAtAction(nameof(Post),new {id= tipo_movimientoDto.Id}, tipo_movimientoDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Tipo_movimiento>> Put(int id, [FromBody]Tipo_movimiento tipo_movimiento){
        if(tipo_movimiento == null)
            return NotFound();
        _unitofwork.Tipo_Movimientos.Update(tipo_movimiento);
        await _unitofwork.SaveAsync();
        return tipo_movimiento;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Tipo_Movimientos.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Tipo_Movimientos.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}