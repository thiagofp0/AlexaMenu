using System;
using System.Net.Http;
using System.Threading.Tasks;
using AlexaMenu.Models;

namespace AlexaMenu.Interfaces
{
    public interface IMenuProvider
    {
        public Task<ApiContent> RequestMenu(DateTime date);
        public Menu GetCurrentMenu();
        public Menu GetNextMenu();
        public Menu GetLastMenu();
        public string GetCurrentMenuOutput();
    }
}