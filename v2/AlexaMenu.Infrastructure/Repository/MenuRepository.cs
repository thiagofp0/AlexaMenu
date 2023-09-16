using AlexaMenu.Domain.Entities;
using AlexaMenu.Domain.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;

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
