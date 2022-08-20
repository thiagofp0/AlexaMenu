using AlexaMenu.Domain.Models;
using AlexaMenu.Interfaces;
using Moq;
using AlexaMenu.Providers;
using AlexaMenu.Repositories;
using Castle.Components.DictionaryAdapter.Xml;

namespace AlexaMenuTest;

[TestClass]
public class GetMenuTest
{
    private static Mock<IMenuRepository> _menuRepository = new Mock<IMenuRepository>();
    private Menu _menu;
    
    [TestInitialize]
    public void Setup()
    {
        _menu = new Menu()
        {
            Date = new DateTime(2022, 01, 01),
            Meals = new List<Meal>
            {
                new Meal
                {
                    Id = 3,
                    Name = "Café da manhã",
                    Restaurant = "RU 1 - (Velho)",
                    StartTime = new DateTime(2022, 01, 01, 06, 15, 0),
                    EndTime = new DateTime(2022, 01, 01, 08, 00, 0),
                    Dishes =
                    {
                        new Dish{Name = "Café com açúcar", Category = "Café", Note = ""},
                        new Dish{Name = "Café sem açucar", Category = "Café", Note = ""},
                        new Dish{Name = "Leite", Category = "Leite", Note = ""},
                        new Dish{Name = "Melancia", Category = "Fruta", Note = ""},
                        new Dish{Name = "Pão com margarina", Category = "Pão", Note = ""},  
                    }
                },
                new Meal
                {
                    Id = 4,
                    Name = "Almoço",
                    Restaurant = "RU 1 - (Velho)",
                    StartTime = new DateTime(2022, 01, 01, 10, 30, 0),
                    EndTime = new DateTime(2022, 01, 01, 13, 30, 0),
                    Dishes =
                    {
                        new Dish{Name = "Repolho com Rúcula", Category = "SALADA 1", Note = ""},
                        new Dish{Name = "Pepino", Category = "SALADA 2", Note = ""},
                        new Dish{Name = "Antepasto de Berinjela", Category = "SALADA 3", Note = ""},
                        new Dish{Name = "Bife Suíno", Category = "PRATO PRINCIPAL", Note = ""},
                        new Dish{Name = "Ervilha à Primavera", Category = "OPÇÃO VEGANA", Note = ""},
                        new Dish{Name = "Omelete com Cheiro Verde", Category = "OPÇÃO VEGETARIANA", Note = ""},
                        new Dish{Name = "Legumes ao Alho", Category = "GUARNIÇÃO", Note = ""},
                        new Dish{Name = "Arroz e Feijão", Category = "ACOMPANHAMENTO", Note = ""},
                        new Dish{Name = "Doce de Mamão com Coco", Category = "SOBREMESA", Note = ""},
                        new Dish{Name = "Abacaxi", Category = "REFRESCO", Note = ""}
                    }
                },
                new Meal
                {
                    Id = 5,
                    Name = "Jantar",
                    Restaurant = "RU 1 - (Velho)",
                    StartTime = new DateTime(2022, 01, 01, 17, 00, 0),
                    EndTime = new DateTime(2022, 01, 01, 19, 00, 0),
                    Dishes =
                    {
                        new Dish{Name = "Almeirão", Category = "SALADA 1", Note = ""},
                        new Dish{Name = "Abobrinha", Category = "SALADA 2", Note = ""},
                        new Dish{Name = "Chuchu", Category = "SALADA 3", Note = ""},
                        new Dish{Name = "Carne Moída com Cenoura e Ervilha", Category = "PRATO PRINCIPAL", Note = ""},
                        new Dish{Name = "Bobó de Feijão Branco", Category = "OPÇÃO VEGANA", Note = ""},
                        new Dish{Name = "Ovos Mexidos", Category = "OPÇÃO VEGETARIANA", Note = ""},
                        new Dish{Name = "Polenta ao Sugo", Category = "GUARNIÇÃO", Note = ""},
                        new Dish{Name = "Arroz e Feijão", Category = "ACOMPANHAMENTO", Note = ""},
                        new Dish{Name = "Melancia", Category = "SOBREMESA", Note = ""},
                        new Dish{Name = "Abacaxi", Category = "REFRESCO", Note = ""}
                    }
                }
            }
        };
        _menuRepository.Setup(x => x.GetMenu(It.IsAny<DateTime>())).Returns(_menu);
    }
    
    [TestMethod]
    public void GetCurrentMenuTest()
    {
        var assert = 
            "Hoje no café teremos Pão com margarina. No Almoço o prato principal é Bife Suíno. " +
            "No jantar, o prato é Carne Moída com Cenoura e Ervilha";

        
        MenuProvider menuProvider = new MenuProvider(_menuRepository.Object);
        
        var result = menuProvider.GetCurrentMenu();
        Assert.AreEqual(assert, result);

    }
}