using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.DTOs.ForumDTOs
{
    public class ForumDTO
    {
        public int Id { get; set; }
        public ICollection<PostDTO> Posts { get; set; }
        public ICollection<UserDTOForum> Users { get; set; }
        public int AdvertisementId { get; set; }
    }
}
