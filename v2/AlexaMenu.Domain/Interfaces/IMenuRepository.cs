using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Entities;


namespace AlexaMenu.Domain.Interfaces
{
    public interface IMenuRepository
    {
        public Task<Menu> Get(DateTime date);
        public void Set(MenuSaveCommandObject menu);
    }
}
