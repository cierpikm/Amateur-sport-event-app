using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model
{
    public class Event : Advertisement
    {
        public string Organizer { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string InstagramURL { get; set; }
        public string OfficialPageURL { get; set; }
        public ICollection<Sponsor> Sponsors{ get; set; }
    }
}
