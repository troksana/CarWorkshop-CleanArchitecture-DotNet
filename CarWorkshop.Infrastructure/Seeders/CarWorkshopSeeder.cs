using CarWorkshop.Infrastructure.Persistance;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;//Przechowuje wstrzyknięty obiekt DbContext (czyli Twoje "połączenie z bazą")
        //readonly – oznacza, że zostanie ustawione raz (w konstruktorze) i potem niezmienne
        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed() //Dodanie przykładowych danych do bazy, jeśli ta jest pusta
        {
            if (await _dbContext.Database.CanConnectAsync())// spr czy polaczenie do bazy danych jest mozliwe
            {
                if (!_dbContext.CarWorkshops.Any()) //spr czy tabela z carWorskshop'ami jest pusta, tylko wtedy doda mazde
                {
                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new()
                        {
                            City ="Kraków",
                            Street = "Szewska 2",
                            PhoneNumber ="+48 699222776"
                        }

                    };
                    mazdaAso.EncodeName();
                    _dbContext.CarWorkshops.Add(mazdaAso); //Obiekt mazdaAso trafia do pamięci EF Core, jeszcze nie do bazy danych
                    //Dopiero SaveChangesAsync() zapisze go na stałe
                    await _dbContext.SaveChangesAsync(); //EF zobaczy jakie zmiany zaszly w pamieci
                    //EF Core sprawdza, co zostało zmienione (w tym przypadku: nowy obiekt dodany)

                }
            }
        }
    }
}


