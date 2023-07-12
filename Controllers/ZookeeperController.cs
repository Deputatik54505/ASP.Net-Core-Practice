using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.models;
using Model.repositories;

namespace ASPPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZookeeperController : Controller
    {
        private readonly IZookeeperRepository _repository;
        private readonly IMapper _mapper;

        public ZookeeperController(IZookeeperRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(200, Type = typeof(ZookeeperDto))]
        [ProducesResponseType(404)]
        public IActionResult GetZookeeper(int id)
        {
            var zookeeperDto = _mapper.Map<ZookeeperDto>(_repository.GetZookeeper(id).Result);
            if (zookeeperDto == null)
                return NotFound();
            return Ok(zookeeperDto);
        }

        [HttpGet]
        [Route("getZookeepers")]
        [ProducesResponseType(200, Type = typeof(List<ZookeeperDto>))]
        [ProducesResponseType(404)]
        public IActionResult GetZookeepers()
        {
            var zookeeperDtos = _mapper.Map<List<ZookeeperDto>>(_repository.GetZookeepers().Result);
            if (zookeeperDtos == null)
                return NotFound();
            return Ok(zookeeperDtos);
        }

        [HttpPut]
        [Route("UpdateZookeeper/{id}")]
        [ProducesResponseType(200, Type = typeof(Zookeeper))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateZookeeper(int id, [FromBody] ZookeeperDto dto)
        {
            var zookeeper = _mapper.Map<Zookeeper>(dto);
            if (_repository.GetZookeeper(id).Result == null)
                return NotFound();
            if (!_repository.UpdateZookeeper(id, zookeeper))
                return BadRequest();
            var dto2 = _mapper.Map<ZookeeperDto>(_repository.GetZookeeper(id).Result);
            return Ok(dto2);
        }
    }
}
