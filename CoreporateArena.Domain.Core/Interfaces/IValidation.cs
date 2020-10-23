using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateArena.DataAccess.Interfaces
{
    public interface IValidation
    {
        List<string> ValidationErrors();
    }
}
