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
        [HttpGet("{id}")]
        public ActionResult <PopReadDto> GetPopById(int id)
        {
            var popItem = _repository.GetPopById(id);
            if (popItem != null)
            {
                return Ok(_mapper.Map<PopReadDto>(popItem));
            }
            return NotFound();
            
        }
    }
}