using System;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaMenu.Interfaces;
using AlexaMenu.Models;
using AlexaMenu.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private MenuProvider _menuProvider = new MenuProvider();
        
        [HttpPost, Route("/menu")] 
        public SkillResponse GetMenu(SkillRequest input)
        {
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();
            
            
            switch (input.Request.Type)
            {
                case "LaunchRequest":
                    Menu menu = _menuProvider.GetCurrentMenu();
                    break;
                case "IntentRequest":
                    
                    IntentRequest intentRequest = (IntentRequest) input.Request;
                    string intentType = intentRequest.Intent.Name;

                    SwitchIntent(intentType);
                    
                    break;
                default:
                    break;
            }
            output.Response.OutputSpeech = new PlainTextOutputSpeech("Vrau");
            return output;
        }

        private SkillResponse SwitchIntent(string intentType)
        {
            Menu menu = new Menu();
            SkillResponse output = new SkillResponse();
            
            if (intentType == "GetCurrentMenu")
            {
                menu = _menuProvider.GetCurrentMenu();
            }

            return output;
        }
    }
}