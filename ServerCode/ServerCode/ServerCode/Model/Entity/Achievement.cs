using System;

namespace ServerCode.Model
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Ranking { get; set; }
        public string ExtraInformation { get; set; }
        public string UserId { get; set; }
    }
}