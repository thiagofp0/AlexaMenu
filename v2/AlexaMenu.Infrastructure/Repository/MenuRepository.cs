using AlexaMenu.Domain.Entities;
using AlexaMenu.Domain.Interfaces;


namespace AlexaMenu.Infrastructure.Repository
{
    public class MenuRepository : IMenuRepository
    {
        public Task<Menu> GetCurrentMenu()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Menu>> GetMenuByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
