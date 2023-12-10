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
            //Pegar data atual e format�-la no padr�o da api da ufv
            //Fazer a requisi��o
            //Criar um objeto que fa�a sentido
            //Desserializar os valores
            //Criar adapter do mongoDB
            //Salvar no mongoDB
            //Requisi��o na api para atualizar singleton
            var menu = await _universityService.GetMenu(DateTime.Now);
            var menuSaveCommandObject = new MenuSaveCommandObject(menu.Meals, menu.Date);
            _menuRepository.Set(menuSaveCommandObject);
        }
    }
}
