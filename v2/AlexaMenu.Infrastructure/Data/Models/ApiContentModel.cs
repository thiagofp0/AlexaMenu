
namespace AlexaMenu.Infrastructure.Data.Models
{
    public class ApiContentModel
    {
        public bool retorno { get; private set; }
        public List<ApiDataObject> dados { get; private set; } = new();
        
    }
}
