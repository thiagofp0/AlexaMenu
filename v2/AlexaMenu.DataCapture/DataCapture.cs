using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Interfaces;
using Microsoft.Azure.Functions.Worker;

namespace AlexaMenu.DataCapture
{
    public class DataCapture
    {
        private readonly IUniversityService _universityService;
        private readonly IMenuRepository _menuRepository;

        public DataCapture(IUniversityService universityService, IMenuRepository menuRepository)
        {
            _universityService = universityService;
            _menuRepository = menuRepository;
        }

        [Function("DataCapture")]
        public async Task Run([TimerTrigger("%schedule%")] FunctionContext context)
        {
            //Pegar data atual e formatá-la no padrão da api da ufv
            //Fazer a requisição
            //Criar um objeto que faça sentido
            //Desserializar os valores
            //Criar adapter do mongoDB
            //Salvar no mongoDB
            //Requisição na api para atualizar singleton
            var menu = await _universityService.GetMenu(DateTime.Now);
            var menuSaveCommandObject = new MenuSaveCommandObject(menu.Meals, menu.Date);
            _menuRepository.Set(menuSaveCommandObject);
        }
    }
}
