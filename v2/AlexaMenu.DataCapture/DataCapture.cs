using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Interfaces;
using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AlexaMenu.DataCapture
{
    public class DataCapture
    {
        private readonly ILogger _logger;
        private readonly IUniversityService _universityService;
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public DataCapture(IUniversityService universityService, IMenuRepository menuRepository, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DataCapture>();
            _universityService = universityService;
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        [Function("DataCapture")]
        public async Task Run([TimerTrigger("%schedule%")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var teste = await _universityService.GetMenu(DateTime.Now);
            var menuSaveCommandObject = _mapper.Map<MenuSaveCommandObject>(teste);
            _menuRepository.Set(menuSaveCommandObject);
        }
    }
}
