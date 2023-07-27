using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace one.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testingController : ControllerBase
    {


        [HttpGet]

        public int get(int id)
        {
            return id;
        }
    }
}
