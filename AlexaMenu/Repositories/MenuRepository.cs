using System.Net.Http.Headers;
using AlexaMenu.Domain;
using AlexaMenu.Domain.Models;
using AlexaMenu.Interfaces;

namespace AlexaMenu.Repositories;
public class MenuRepository : IMenuRepository
{
    public Menu GetMenu(DateTime date)
    {
        Task<ApiContent> response = IMenuRepository.RequestMenu(DateTime.Now);
        return MenuUtils.BuildMenu(response);
    }
}