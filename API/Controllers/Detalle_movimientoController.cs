using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class Detalle_movimientoController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public Detalle_movimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Detalle_movimientoDto>>> Get()
    {
        var detalle_mov = await  _unitofwork.Citas.GetAllAsync();
        return _mapper.Map<List<Detalle_movimientoDto>>(detalle_mov);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Detalle_movimientoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Citas.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<Detalle_movimientoDto>>(pag.registros);
        return new Pager<Detalle_movimientoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }



     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Detalle_Movimientos.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Detalle_movimiento>> Post(Detalle_movimientoDto detalle_movimientoDto){
        var detalle_movimiento = _mapper.Map<Detalle_movimiento>(detalle_movimientoDto);
        this._unitofwork.Detalle_Movimientos.Add(detalle_movimiento);
        await _unitofwork.SaveAsync();
        if(detalle_movimiento == null)
        {
            return BadRequest();
        }
        detalle_movimiento.Id = detalle_movimiento.Id;
        return CreatedAtAction(nameof(Post),new {id= detalle_movimiento.Id}, detalle_movimiento);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Detalle_movimiento>> Put(int id, [FromBody]Detalle_movimiento detalle_movimiento){
        if(detalle_movimiento == null)
            return NotFound();
        _unitofwork.Detalle_Movimientos.Update(detalle_movimiento);
        await _unitofwork.SaveAsync();
        return detalle_movimiento;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Detalle_Movimientos.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Detalle_Movimientos.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}