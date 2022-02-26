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
            return "200 - OK";
        }
    }
}