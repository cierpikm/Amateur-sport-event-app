using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model
{
    public class SportName
    {
        public int Id { get; set; }
        public Sports Vaule { get; set; }
        public string UserId { get; set; }
    }
    public enum Sports
    {
        Handball, TableTennis, Billiard, Swimming, Cycling, Badminton, Baseball, Football, Volleyball, Hockey, Tennis, Basketball, Other
    }
}
