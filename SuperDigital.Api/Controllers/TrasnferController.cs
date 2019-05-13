using Microsoft.AspNetCore.Mvc;
using SuperDigital.Domain.Entity;
using SuperDigital.Services;
using System.Linq;

namespace SuperDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrasnferController : ControllerBase
    {
        [Route("~/api/SuperDigital")]
        [HttpPost]
        public IActionResult Post([FromBody] LancamentoEntity data)
        {
            var lancto = new TransferApp(data);
            if (lancto.errors.Any()) 
            {
                return NoContent(); 
            }
            else
            {
                return Ok();
            }
        }
    }
}