using System;

namespace ServerCode.Model
{
    public class Localization
    {
        public int  Id { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public int AdvertisementId { get; set; }

    }
}