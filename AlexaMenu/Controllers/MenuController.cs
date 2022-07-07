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
                IntentRequest intentRequest = (IntentRequest) input.Request;
                string intentType = intentRequest.Intent.Name;
                output.Response.OutputSpeech = new PlainTextOutputSpeech(SwitchIntent(intentType));
            }
            return output;
        }

        private string SwitchIntent(string intentType)
        {
            Menu menu = new Menu();
 
            if (intentType == "GetCurrentMenu")
            {
                menu = _menuProvider.GetCurrentMenu();
                var breakfest = menu.Meals.Where(x => x.Id == 3).First().Dishes.Where(x=>x.Category.Equals("MINGAU")).First().Name;
                var lunch = menu.Meals.Where(x => x.Id == 4).First().Dishes.Where(x=>x.Category.Equals("PRATO PRINCIPAL")).First().Name;
                var dinner = menu.Meals.Where(x => x.Id == 5).First().Dishes.Where(x=>x.Category.Equals("PRATO PRINCIPAL")).First().Name;
                var snack = menu.Meals.Where(x => x.Id == 6).First().Dishes.Where(x=>x.Category.Equals("RECHEIO PARA PÃO")).First().Name;
                return $"Hoje no café teremos {breakfest}. No Almoço o prato principal é {lunch}. No jantar, o prato é {dinner}. Já no lanche o recheio do pão é {snack}.";
            }
            return null;
        }
    }
}