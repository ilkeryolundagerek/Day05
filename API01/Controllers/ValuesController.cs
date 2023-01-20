using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.HR;

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
    }
}
