using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Database
{
    public static class DbInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Localization>().HasData(new Localization { Id = 1, Street = "Piotrkowska", StreetNumber = 145, City = "Łódź" });


           // modelBuilder.Entity<Achievement>().HasData(new Achievement { Id = 1, Title = "Zawody wojewódzkie w jeżdziectwie", Ranking = "1", ExtraInformation = "brak" });
        
            //modelBuilder.Entity<User>().HasData(new User{  FirstName = "Maciej",
            //    LastName = "Cierpikowski",
            //    Description = "Lubie sport",
            //    Age = 22,
            //    ImageURL = "http://images.clipartpanda.com/user-clipart-matt-icons_preferences-desktop-personal.png",
            //    Email = "cierpikm@mail.com",
             
            //    PrefferedSports = Sports.Cycling,
           
            //    AchievementID = 1
            //});
         
        }
    }
}
