using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AlexaMenu.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class DataCaptureController : ControllerBase
    {
        private IMenuRepository _menuRepository;
        private IUniversityService _universityService;
        private IMapper _mapper;

        public DataCaptureController(IMenuRepository menuRepository, IUniversityService universityService, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _universityService = universityService;
            _mapper = mapper;
        }

        [HttpGet("get-ufv-menu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> Get([BindRequired] DateTime date)
        {
            var menu = _mapper.Map<MenuSaveCommandObject>(await _universityService.GetMenu(date));
            _menuRepository.Set(menu);
            return new OkObjectResult(menu);
        }
    }
}
