using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Helpers
{
    public class ChangePassword
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }

    }
}
