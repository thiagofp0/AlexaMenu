using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaMenu.AlexaInterface.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.AlexaInterface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaInterfaceController : ControllerBase
    {
        private IMenuProvider _menuProvider;
        public AlexaInterfaceController(IMenuProvider menuProvider)
        {
            _menuProvider = menuProvider;
        }

        [HttpPost("menu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public SkillResponse GetMenu(SkillRequest input)
        {
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();


            if (input.Request.Type == "LaunchRequest")
            {
                string menuOutput = _menuProvider.GetCurrentMenu();
                output.Response.OutputSpeech = new PlainTextOutputSpeech(menuOutput);
                output.Response.ShouldEndSession = true;

            }
            else if (input.Request.Type == "IntentRequest")
            {
                IntentRequest intentRequest = (IntentRequest)input.Request;
                string intentType = intentRequest.Intent.Name;
                output.Response.OutputSpeech = new PlainTextOutputSpeech(SwitchIntent(intentType));
                output.Response.ShouldEndSession = true;
            }
            return output;
        }

        private string SwitchIntent(string intentType)
        {
            if (intentType == "GetCurrentMenu")
            {
                return _menuProvider.GetCurrentMenu();
            }
            return string.Empty;
        }
    }
}
