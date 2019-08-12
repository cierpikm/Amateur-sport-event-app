using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model
{
    public class Sponsor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int EventId { get; set; }
    }
}
