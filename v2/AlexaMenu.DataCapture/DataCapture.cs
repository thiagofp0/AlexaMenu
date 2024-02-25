using System;
using AlexaMenu.Domain.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AlexaMenu.DataCapture
{
    public class DataCapture
    {
        private readonly ILogger _logger;
        private readonly IUniversityService _universityService;
        private readonly IMenuRepository _menuRepository;

        public DataCapture(IUniversityService universityService, IMenuRepository menuRepository, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DataCapture>();
            _universityService = universityService;
            _menuRepository = menuRepository;
        }

        [Function("DataCapture")]
        public void Run([TimerTrigger("%schedule%")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var teste = _universityService.GetMenu(DateTime.Now);
            //_menuRepository.Set(teste);
        }
    }
}
