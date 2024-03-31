using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.AlexaInterface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaInterfaceController : ControllerBase
    {
        [HttpPost(Name = "menu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public SkillResponse GetMenu()
        {
            return new SkillResponse();
        }
    }
}
