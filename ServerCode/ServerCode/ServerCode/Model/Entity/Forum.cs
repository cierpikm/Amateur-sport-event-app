using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Entity
{
    public class Forum
    {
        public int Id { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<User> Users { get; set; }
        public int AdvertisementId { get; set; }
    }
}
