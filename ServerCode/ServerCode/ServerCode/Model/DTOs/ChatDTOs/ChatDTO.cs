using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.DTOs.ChatDTOs
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public ICollection<MessageDTO> Messages { get; set; }
        public UserChatDTO Owner { get; set; }
        public UserChatDTO Reciver { get; set; }
    }
}
