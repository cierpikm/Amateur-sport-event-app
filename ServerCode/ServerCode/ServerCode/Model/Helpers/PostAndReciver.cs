using ServerCode.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Helpers
{
    public class PostAndReciver
    {
        public int Id { get; set; }
        public string PostText { get; set; }
        public DateTime DateSendMessage { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
        public List<string> Reciver { get; set; }
    }
}
