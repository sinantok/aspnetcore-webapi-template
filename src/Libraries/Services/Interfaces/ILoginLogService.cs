using Data.Mongo.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    interface ILoginLogService
    {
        Task Add(LoginLog model);
        Task<List<LoginLog>> Get();
    }
}
