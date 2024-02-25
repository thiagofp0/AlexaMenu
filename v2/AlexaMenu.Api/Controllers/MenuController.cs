using AlexaMenu.Api.Models;
using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuRepository _menuRepository;
        private IUniversityService _universityService;
        private IMapper _mapper;

        public MenuController(IMenuRepository menuRepository, IUniversityService universityService, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _universityService = universityService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetMenu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> Get(DateTime date)
        {
            var menu = _mapper.Map<MenuApiModel>(await _menuRepository.Get(date));
            return new OkObjectResult(menu);
        }

        [HttpPost(Name = "SetMenu")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ObjectResult Set(MenuApiModel model)
        {
            var commandObject = _mapper.Map<MenuSaveCommandObject>(model);
            _menuRepository.Set(commandObject);
            return Ok("Menu saved.");
        }
    }
}