using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public DateTime dateSendMessage { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public string ReciverId { get; set; }
        public User Reciver { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
