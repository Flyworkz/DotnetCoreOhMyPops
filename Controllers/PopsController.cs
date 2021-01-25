using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OhMyPops.Data;
using OhMyPops.Dtos;
using OhMyPops.Models;

namespace OhMyPops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopsController : ControllerBase
    {
        private readonly IOhMyPopsRepo _repository;
        private readonly IMapper _mapper;

        public PopsController(IOhMyPopsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        // GET api/pops
        [HttpGet]
        public ActionResult <IEnumerable<PopReadDto>> GetAllPops() 
        {
            var popItems = _repository.GetAllPops();

            return Ok(_mapper.Map<IEnumerable<PopReadDto>>(popItems));
        }

        // GET api/pops/{id}
        [HttpGet("{id}", Name="GetPopById")]
        public ActionResult <PopReadDto> GetPopById(int id)
        {
            var popItem = _repository.GetPopById(id);
            if (popItem != null)
            {
                return Ok(_mapper.Map<PopReadDto>(popItem));
            }
            return NotFound();
            
        }

        // POST api/pops
        [HttpPost]
        public ActionResult <PopReadDto> CreatePop(PopCreateDto popCreateDto)
        {
            var popModel = _mapper.Map<Pop>(popCreateDto);
            _repository.CreatePop(popModel);
            _repository.SaveChanges();

            var popReadDto = _mapper.Map<PopReadDto>(popModel);
            
            return CreatedAtRoute(nameof(GetPopById), new {Id = popReadDto.Id}, popReadDto);
        }
    }
}