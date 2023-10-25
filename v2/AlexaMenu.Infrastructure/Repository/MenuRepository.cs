using AlexaMenu.Domain.Base.Adapters;
using AlexaMenu.Domain.Entities;
using AlexaMenu.Domain.Interfaces;
using AlexaMenu.Infrastructure.Data.Models;
using AlexaMenu.Infrastructure.Database;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

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
        public void Set()
        {
            var teste = new MenuDocumentModel();
            teste.Id = ObjectId.GenerateNewId();
            teste.Date = DateTime.Now;
            teste.Meals = new List<Meal>();

            _collection.InsertOne(teste);
        }

        public async Task<Menu> Get(DateTime date)
        {
            var filter = Builders<MenuDocumentModel>.Filter.Eq(x => x.Date.Date, date.Date);
            return _mapper.Map<Menu>(await _collection.Find(filter).FirstOrDefaultAsync());
        }
    }
}
