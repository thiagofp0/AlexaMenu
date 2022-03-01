using AlexaMenu.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        [HttpPost, Route("/menu")]
        public string GetMenu()
        {
            MenuProvider mp = new MenuProvider();
            return "200 - OK";
        }
    }
}