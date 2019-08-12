using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string ImageURL { get; set; }
        public string City { get; set; }
        public ICollection<SportName> PrefferedSports { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<UserAdvertisement> AdvertisementsAccepted { get; set; }
        public ICollection<UserAdvertisement> OwnAdvertisements { get; set; }

    }

}

