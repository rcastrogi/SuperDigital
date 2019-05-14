using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperDigital.Domain.Entity;
using SuperDigital.Services;
using System.Linq;

namespace SuperDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [Route("~/api/SuperDigital")]
        [HttpPost]
        public IActionResult Post([FromBody] TransferEntity body)
        {
            var header = JsonConvert.SerializeObject(Request.Headers);
            var data = JsonConvert.DeserializeObject<TransferEntity>(header);

            if (data == null)
            {
                data = body;
            }

            var transfer = new TransferApp(data);
            if (transfer.errors.Any()) 
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