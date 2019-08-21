using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.DTOs.ChatDTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public DateTime dateSendMessage { get; set; }
        public UserChatDTO Sender { get; set; }
        public string SenderId { get; set; }
        public UserChatDTO Reciver { get; set; }
        public string ReciverId { get; set; }
        public int ChatId { get; set; }
    }
}
