using System;
using System.Threading.Tasks;
using AlexaMenu.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        [HttpPost, Route("/menu")]
        public Task<string> GetMenu()
        {
            MenuProvider mp = new MenuProvider();
            return mp.Init(DateTime.Now);
        }
    }
}