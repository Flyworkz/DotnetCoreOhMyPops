using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OhMyPops.Data;
using OhMyPops.Models;

namespace OhMyPops.Controllers
{
    [Route("api/pops")]
    [ApiController]
    public class PopsController : ControllerBase
    {
        private readonly IOhMyPopsRepo _repository;

        public PopsController(IOhMyPopsRepo repository)
        {
            _repository = repository;
        }

        // private readonly MockOhMyPopsRepo _repository = new MockOhMyPopsRepo();
        // GET api/pops
        [HttpGet]
        public ActionResult <IEnumerable<Pop>> GetAllPops() 
        {
            var popItems = _repository.GetAppPops();

            return Ok(popItems);
        }

        // GET api/pops/{id}
        [HttpGet("{id}")]
        public ActionResult <Pop> GetPopById(int id)
        {
            var popItem = _repository.GetPopById(id);
            return Ok(popItem);
        }
    }
}