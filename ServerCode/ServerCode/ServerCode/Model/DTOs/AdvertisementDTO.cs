using ServerCode.Model.DTOs.ForumDTOs;
using ServerCode.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.DTOs
{
    public class AdvertisementDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Sports SportType { get; set; }
        public DateTime Date { get; set; }
        public Localization Localization { get; set; }
        public LevelUser LevelUser { get; set; }
        public int AgeRange { get; set; }
        public string ExtraInformation { get; set; }
        public string ImageURL { get; set; }
        public string UserId { get; set; }
        public UserDTO UserDTO { get; set; }
        public ICollection<UserDTO> EagerMembers { get; set; }
        public ForumDTO Forum { get; set; }
    }
}
