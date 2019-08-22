using ServerCode.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Sports SportType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Localization Localization { get; set; }
        public LevelUser LevelUser { get; set; }
        public int AgeRange { get; set; }
        public string ExtraInformation { get; set; }
        public string ImageURL { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<UserAdvertisement> EagerMembers { get; set; }
      //  public Forum Forum { get; set; }

    }
    public enum LevelUser
    {
        good, intermediate, advanced
    }
}
