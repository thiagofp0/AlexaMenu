using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IConfiguration _configuration;

        public MenuController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GetMenu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Get()
        {
            var teste = _configuration.GetValue<string>("MongoDB:ConnectionString");
            return Ok(teste);
        }
    }
}
