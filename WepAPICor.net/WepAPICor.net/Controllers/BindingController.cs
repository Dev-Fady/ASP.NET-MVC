using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepAPICor.net.Models;

namespace WepAPICor.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        // api/Binding/ahmed/12
        [HttpGet("{name:alpha}/{age:int}")]
        public IActionResult testPrimitive(int age, string name) {
            return Ok();
        }

     
        /*
         http://localhost:5025/api/Binding?name=fady
        Body => raw
        {
          "Id": 1,
          "Title": "HR"
        }
         */
        [HttpPost]
        public IActionResult TestObj(Department1 dept, string name)
        {
            return Ok();
        }
       
        [HttpGet("{id}/{name}/{mangerName}")]
        public IActionResult TestCustomer(
            [FromQuery]Department1 dept
            )
        {
            return Ok();
        }

        [HttpGet("{id}/{name}")]
        public IActionResult TestCustomer1(
          [FromQuery] Department1 dept
            , [FromBody] int age
          )
        {
            return Ok();
        }

    }
}
