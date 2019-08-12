using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public ICollection<Message> Messages { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public string ReciverId { get; set; }
        public User Reciver { get; set; }

    }
}
