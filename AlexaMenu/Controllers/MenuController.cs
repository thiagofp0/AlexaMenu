using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaMenu.Models;
using AlexaMenu.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private MenuProvider menuProvider = new MenuProvider();
        
        [HttpPost, Route("/menu")] 
        public SkillResponse GetMenu(SkillRequest input)
        {
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();
            
            switch (input.Request.Type)
            {
                case "LaunchRequest":
                    output.Response.OutputSpeech = new PlainTextOutputSpeech("Launch Request!");
                    Menu menu = menuProvider.GetCurrentMenu();
                    break;
                case "IntentRequest":
                    
                    IntentRequest intent = (IntentRequest)input.Request;
                    string intentType = intent.Intent.Name;
                    SwitchIntent(intentType);
                    
                    break;
                case "SessionEndedRequest":
                    break;
            }
            return output;
        }

        private SkillResponse SwitchIntent(string intentType)
        {
            Menu menu = new Menu();
            SkillResponse output = new SkillResponse();

            if (intentType == "GetCurrentMenu")
            {
                menu = menuProvider.GetCurrentMenu();
                output.Response.OutputSpeech = new PlainTextOutputSpeech("Menu do dia");
            }

            return output;
        }
    }
}