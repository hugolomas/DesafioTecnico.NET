using Microsoft.AspNetCore.Mvc;

namespace SoftP.ApiDotNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowmethecodeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetShowMeTheCode()
        {
            var result = "https://github.com/hugolomas/DesafioTecnico.NET";

            return Ok(result);
        }
    }
}
