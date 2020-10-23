using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Presentation
{
    public class JwtOpt
    {
        public string Secret { get; set; }

        public string ExpiryTime { get; set; }
    }
}
