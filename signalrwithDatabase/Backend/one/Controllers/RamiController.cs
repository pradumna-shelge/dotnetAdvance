using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using one.Models;

namespace one.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamiController : ControllerBase
    {
        private readonly RasmitestContext _context;

        public RamiController(RasmitestContext context)
        {
                _context = context;
        }


        [HttpGet]

        public ActionResult Get()
        {
            var data = from p in _context.Mes.ToList()
                       select new
                       {
                           userId = p.UserId,
                           mes = p.Mes,
                       };
            return Ok(data);
        }
    }
}
