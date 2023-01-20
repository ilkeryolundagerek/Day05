using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IPersonService _personService;
        public ValuesController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<PersonListItemDTO>> Get()
        {
            return await _personService.GetPeopleAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<PersonDetailDTO> Get(int id)
        {
            return await _personService.GetPersonDetailAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
