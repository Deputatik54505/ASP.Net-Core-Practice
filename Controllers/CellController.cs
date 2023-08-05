using ASPPractice.Model.Dto;
using ASPPractice.Model.models;
using ASPPractice.Model.repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPPractice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CellController : Controller
{
    private readonly ICellRepository _repository;
    private readonly IMapper _mapper;

    public CellController(ICellRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    [HttpGet]
    [Route("getCells")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CellDto>))]
    [ProducesResponseType(400)]
    public IActionResult GetCells()
    {
        var cells = _mapper.Map<List<CellDto>>(_repository.GetCells().Result);
        return Ok(cells);
    }

    [HttpGet]
    [Route("getCell/{id}")]
    [ProducesResponseType(200, Type = typeof(CellDto))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult GetCell(int id)
    {
        var cell = _mapper.Map<CellDto>(_repository.GetCell(id).Result);
        if (cell == null)
        {
            return NotFound();
        }
        return Ok(cell);
    }

    [HttpDelete]
    [Route("removeCell/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public IActionResult DeleteCell(int id)
    {
        if (_repository.GetCell(id).Result == null)
            return NotFound();
        if (!_repository.RemoveCell(id))
            return BadRequest();
        return StatusCode(204);
    }

    [HttpPost]
    [Route("addCell")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult AddCell([FromBody] CellDto cellDto)
    {
        var cell = _mapper.Map<Cell>(cellDto);

        if (cell == null)
            return BadRequest();
        if (!_repository.AddCell(cell))
            return BadRequest();
        return StatusCode(204);
    }

    [HttpPut]
    [Route("editCell/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCell(int id, [FromBody] CellDto cellDto)
    {
        var cell = _mapper.Map<Cell>(cellDto);
        if (cell.Id != id)
            return BadRequest();
        if (_repository.GetCell(id).Result == null)
            return NotFound();
        return !_repository.UpdateCell(id, cell) ? BadRequest() : StatusCode(204);
    }

    [HttpGet]
    [Route("{id}/animals")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public IActionResult GetAnimals(int id)
    {
        if (_repository.GetCell(id).Result == null)
            return NotFound();
        var animals = _mapper.Map<List<AnimalDto>>(_repository.GetAnimals(id).Result);
        return Ok(animals);
    }

}
