using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace aspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPatch]
        public IActionResult JsonPatchForDynamic([FromBody] JsonPatchDocument patch)
        {
            dynamic obj = new ExpandoObject();
            patch.ApplyTo(obj);

            return Ok(obj);
        }
    }
}
