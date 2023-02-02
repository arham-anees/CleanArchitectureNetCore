using CleanArchitectureNetCore.Application.Services;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureNetCore.WebApi.ActionFilters;

namespace CleanArchitectureNetCore.WebApi.Controllers
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

    [Authorize("user")]
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
