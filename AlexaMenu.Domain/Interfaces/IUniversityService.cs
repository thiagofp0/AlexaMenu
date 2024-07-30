using AlexaMenu.Domain.Entities;

namespace AlexaMenu.Domain.Interfaces
{
    public interface IUniversityService
    {
        public Task<Menu> GetMenu(DateTime date);
    }
}
