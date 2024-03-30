using AlexaMenu.Domain.Base.Adapters;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AlexaMenu.Infrastructure.Database
{
    public class DatabaseConnection : IDatabaseAdapter<MongoClient>
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public MongoClient GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("mongoDB");

            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            return new MongoClient(settings);
        }
    }
}
