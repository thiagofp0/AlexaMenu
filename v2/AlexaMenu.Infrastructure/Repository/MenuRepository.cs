using AlexaMenu.Domain.Base.Adapters;
using AlexaMenu.Domain.Base.Exceptions;
using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Entities;
using AlexaMenu.Domain.Interfaces;
using AlexaMenu.Infrastructure.Data.Models;
using AlexaMenu.Infrastructure.Database;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AlexaMenu.Infrastructure.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IDatabaseAdapter<MongoClient> _databaseAdapter;
        private MongoClient _client;
        private IMongoCollection<MenuDocumentModel> _collection;
        private IMapper _mapper;

        public MenuRepository(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            _databaseAdapter = new DatabaseConnection(configuration);
            _client = _databaseAdapter.GetConnection();
            _collection = _client.GetDatabase("Menu").GetCollection<MenuDocumentModel>("Menu");
        }
        public void Set(MenuSaveCommandObject menu)
        {
            _collection.InsertOne(_mapper.Map<MenuDocumentModel>(menu));
        }
        
        public async Task<Menu> Get(DateTime date)
        {
            var filter = Builders<MenuDocumentModel>.Filter.Eq(x => x.Date, date!.Date.ToShortDateString());
            var result = await _collection.FindAsync(filter).Result.FirstOrDefaultAsync();
            var teste = _mapper.Map<Menu>(result);
            return result == null ? throw new NoResultsException("Menu not found.") : _mapper.Map<Menu>(result);
        }
    }
}
