using AlexaMenu.Domain.Base.Adapters;
using AlexaMenu.Domain.Base.Exceptions;
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
            var connectionString = _configuration.GetConnectionString("mongoDB")
                ?? throw new InfrastructureFailedException("Connection string not found");

            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            return new MongoClient(settings);
        }
    }
}
