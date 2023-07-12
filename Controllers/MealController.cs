using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.repositories;
using Model.Dto;
using Model.models;
using NLog.LayoutRenderers;

namespace ASPPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : Controller
    {
        private readonly IMealRepository _repository;
        private readonly IMapper _mapper;

        public MealController(IMealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getMeals")]
        [ProducesResponseType(200, Type = typeof(List<MealDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetMeals()
        {
            var meals = _mapper.Map<List<MealDto>>(_repository.GetMeals().Result);
            return Ok(meals);
        }

        [HttpPost]
        [Route("addMeal")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddMeal([FromBody] MealDto mealDto)
        {
            var meal = _mapper.Map<Meal>(mealDto);
            if (!_repository.AddMeal(meal))
                return BadRequest();
            return StatusCode(204);
        }

        [HttpDelete]
        [Route("deleteMeal/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteMeal(int id)
        {
            if (!_repository.DeleteMeal(id))
                return BadRequest();
            return StatusCode(204);
        }

        [HttpGet]
        [Route("getMeal/{id}")]
        [ProducesResponseType(200, Type = typeof(MealDto))]
        [ProducesResponseType(404)]
        public IActionResult GetMeal(int id)
        {
            var dto = _mapper.Map<MealDto>(_repository.GetMeal(id).Result);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        [HttpPut]
        [Route("UpdateMeal/{id}")]
        [ProducesResponseType(200, Type = typeof(MealDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateMeal(int id, [FromBody] MealDto mealDto)
        {
            var meal = _mapper.Map<Meal>(mealDto);
            if (_repository.GetMeal(id).Result==null)
                return NotFound();
            if(!_repository.UpdateMeal(id, meal))
                return BadRequest();
            return Ok(_mapper.Map<MealDto>(_repository.GetMeal(id).Result));
        }
    }
}
