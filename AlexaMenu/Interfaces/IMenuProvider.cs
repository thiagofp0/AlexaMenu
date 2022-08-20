using AlexaMenu.Domain.Models;

namespace AlexaMenu.Interfaces
{
    public interface IMenuProvider
    {
        public string GetCurrentMenu();
    }
}