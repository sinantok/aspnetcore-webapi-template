using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserEmail { get; }
    }
}
