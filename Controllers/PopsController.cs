using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        // GET api/pops/collection?q={collection}
        [HttpGet("collection")]
        public ActionResult <PopReadDto> GetPopsByCollection([FromQuery]string q)
        {
            var popItems = _repository.GetPopsByCollection(q);
            if (q != null)
            {
                 return Ok(_mapper.Map<IEnumerable<PopReadDto>>(popItems));
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

        // PUT api/pops/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePop(int id, PopUpdateDto popUpdateDto)
        {
            var popModelFromRepo = _repository.GetPopById(id);
            if (popModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(popUpdateDto, popModelFromRepo);

            _repository.UpdatePop(popModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/pops/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPopUpdate(int id, JsonPatchDocument<PopUpdateDto> patchDoc)
        {
            var popModelFromRepo = _repository.GetPopById(id);
            if (popModelFromRepo == null)
            {
                return NotFound();
            }

            var popToPatch = _mapper.Map<PopUpdateDto>(popModelFromRepo);
            patchDoc.ApplyTo(popToPatch, ModelState);

            if (!TryValidateModel(popToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(popToPatch, popModelFromRepo);

            _repository.UpdatePop(popModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/pops/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePop(int id)
        {
            var popModelFromRepo = _repository.GetPopById(id);
            if (popModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePop(popModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }   
}