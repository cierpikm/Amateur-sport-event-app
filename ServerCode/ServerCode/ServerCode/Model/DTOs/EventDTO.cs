using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Sports SportType { get; set; }
        public DateTime Date { get; set; }
        public Localization Localization { get; set; }
        public string ExtraInformation { get; set; }
        public string ImageURL { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Organizer { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string InstagramURL { get; set; }
        public string OfficialPageURL { get; set; }
        public ICollection<Sponsor> Sponsors { get; set; }
    }
}
