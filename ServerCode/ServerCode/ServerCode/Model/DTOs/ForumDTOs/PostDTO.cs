using System;

namespace ServerCode.Model.DTOs.ForumDTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string PostText { get; set; }
        public DateTime DateSendMessage { get; set; }
        public string OwnerId { get; set; }
        public UserDTOForum Owner { get; set; }
        public int ForumId { get; set; }

    }
}