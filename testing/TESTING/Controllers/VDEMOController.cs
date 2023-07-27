using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TESTING.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VDEMOController : ControllerBase
    {



        [HttpGet("getA")]
       public string Get()
        {
            return "data";
        }



        [HttpPost("postA")]
        public string post(string data)
        {
            return data;
        }

        [HttpGet]
        public  IActionResult newGet()
        {
            return Ok("value");
        }


        [HttpPost]
        public async Task<IActionResult> newppost()
        {

           
            return Ok("value");
        }

    }
}
