using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Model.Dto;
using Model.models;
using Model.repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPPractice.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnimalController : Controller
	{
		private readonly IAnimalRepository _repository;
		private readonly IMapper _mapper;

		public AnimalController(IAnimalRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("getAnimals")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<AnimalDto>))]
		[ProducesResponseType(400)]
		public IActionResult GetAnimals()
		{
			var animals = _mapper.Map<List<AnimalDto>>(_repository.GetAnimals().Result);
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(animals);
		}

		[HttpGet]
		[Route("getAnimal/{id}")]
		[ProducesResponseType(200, Type = typeof(Animal))]
		[ProducesResponseType(404)]
		[ProducesResponseType(400)]
		public IActionResult GetAnimal(int id)
		{

			var animal = _mapper.Map<AnimalDto>(_repository.GetAnimalById(id).Result);
			if (animal == null)
			{
				return NotFound();
			}
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(animal);
		}



		[HttpPost]
		[Route("postAnimal")]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public IActionResult PostAnimal([FromQuery] AnimalDto animalDto)
		{
			var animal = _mapper.Map<Animal>(animalDto);
			if (_repository.Add(animal.CellId, animal.MainMealId, animal))
				return StatusCode(204);
			return BadRequest();
		}

		[HttpPut]
		[Route("updateAnimal/{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public IActionResult UpdateAnimal(int id, [FromBody] AnimalDto animalDto)
		{
			var animal = _mapper.Map<Animal>(animalDto);
			if (_repository.Update(id, animal))
				return Ok();
			return BadRequest();
		}

		[HttpDelete]
		[Route("{id}/delete")]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		[ProducesResponseType(400)]
		public IActionResult DeleteAnimal(int id)
		{
			var animal = _repository.GetAnimalById(id).Result;
			if (animal == null)
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			if (!_repository.Delete(animal))
			{
				return BadRequest();
			}

			return StatusCode(204);
		}

	}
}
