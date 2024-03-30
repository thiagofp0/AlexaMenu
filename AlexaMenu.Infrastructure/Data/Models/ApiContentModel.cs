
namespace AlexaMenu.Infrastructure.Data.Models
{
    public class ApiContentModel
    {
        public bool Retorno { get; set; }
        public List<ApiDataObject> Dados { get; set; } = new();
        
    }
}
