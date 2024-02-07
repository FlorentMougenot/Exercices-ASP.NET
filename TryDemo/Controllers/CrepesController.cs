using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryDemo.Data;
using TryDemo.Models;

namespace TryDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrepesController : ControllerBase
    {
        private readonly CrepeFakeDb _fakeDb;
        public CrepesController(CrepeFakeDb fakeDb)
        {
            _fakeDb = fakeDb;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            var crepes = _fakeDb.Crepes;
            if (crepes.Any())
                return Ok(crepes);
            /*return NotFound();*/
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var crepe = _fakeDb.Crepes.FirstOrDefault(c => c.Id == id);
            if (crepe == null)
                return NotFound();
            /*return NotFound();*/
            return Ok(crepe);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Crepe crepe) 
        {
            _fakeDb.Crepes.Add(crepe);
            return CreatedAtAction(nameof(GetById), new {id = crepe.Id}, "Crêpe ajoutée");
        }

    }
}
