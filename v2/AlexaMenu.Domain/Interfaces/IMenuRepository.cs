using AlexaMenu.Domain.Entities;

namespace AlexaMenu.Domain.Interfaces
{
    public interface IMenuRepository
    {
        public Task<IEnumerable<Menu>> GetMenuByDate(DateTime date);
        public Task<Menu> GetCurrentMenu();
    }
}
