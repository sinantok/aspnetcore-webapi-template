using Data.Mongo.Collections;
using Data.Mongo.Repo;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Services.Concrete
{
    public class LoginLogService : ILoginLogService
    {
        private readonly IMongoRepository<LoginLog> _repository;
        public LoginLogService(IMongoRepository<LoginLog> repository)
        {
            _repository = repository;
        }
        public async Task Add(LoginLog model)
        {
            await _repository.AddAsync(model);
        }

        public async Task<List<LoginLog>> Get(string email)
        {
            var content = await _repository.FindAsync(x => x.UserEmail.Equals(email));
            return content.ToList();
        }
    }
}
