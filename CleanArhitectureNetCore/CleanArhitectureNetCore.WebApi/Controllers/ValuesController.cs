using CleanArhitectureNetCore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArhitectureNetCore.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ValuesService _ValuesService;
        public ValuesController(ValuesService valuesService)
        {
            _ValuesService = valuesService;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult GetValues()
        {
            return Ok(_ValuesService.GetAllValues());
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult GetValues(string value)
        {
            return Ok(_ValuesService.Create(value, 1));
        }
    }
}
