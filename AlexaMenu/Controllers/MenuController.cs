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

            if (input.Request.Type == "LaunchRequest")
            { 
                output.Response.OutputSpeech = new PlainTextOutputSpeech("Vrau");
            }else if (input.Request.Type == "IntentRequest")
            {
                output.Response.OutputSpeech = new PlainTextOutputSpeech("Passou no get");
                //IntentRequest intentRequest = (IntentRequest) input.Request;
                //string intentType = intentRequest.Intent.Name;
                //output = SwitchIntent(intentType);
            }
            
            output.Response.OutputSpeech = new PlainTextOutputSpeech("Passou reto");
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
            Console.Write(menu);
            return output;
        }
    }
}