using AlexaMenu.Domain.Base.Adapters;

namespace AlexaMenu.Infrastructure.Database
{
    public class DatabaseConnection : IDatabaseAdapter<string>
    {
        public string GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
