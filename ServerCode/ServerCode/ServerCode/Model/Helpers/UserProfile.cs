using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Achievement Achievement { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageURL { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
}
