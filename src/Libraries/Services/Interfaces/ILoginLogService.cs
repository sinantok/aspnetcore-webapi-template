using Data.Mongo.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoginLogService
    {
        Task Add(LoginLog model);
        Task<List<LoginLog>> Get(string email);
    }
}
