using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain.Core.Entities
{
    public enum JobType
    {
        [Description("Full Time Jobs")]
        FullTime = 1,
        [Description("Part Time Jobs")]
        PartTime,
        [Description("Remote Jobs")]
        Remote,
        [Description("Contract Jobs")]
        Contract,
        [Description("Consultancy Jobs")]
        Consultant,
        [Description("Freelance Jobs")]
        Freelance
    }
}
